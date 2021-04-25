using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Unity.EditorCoroutines.Editor;

public class LocalizationsLoader
{
    private string _sheetId = "1Q3oh0MHgv8Zjoch2kuQLyG3ggfQyCBxuOFMM4H1AzPU";
    private string _page = "Localizations";

    public IEnumerator DoImport()
    {
        var credentialsJson = AssetDatabase.LoadAssetAtPath<TextAsset>(
            "Assets/Resources/Scripts/Localizations/credentials.json");
        var authTask = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(new MemoryStream(credentialsJson.bytes)).Secrets,
            new string[] { SheetsService.Scope.SpreadsheetsReadonly },
            "user",
            CancellationToken.None,
            new FileDataStore("UnityGoogleApis", false));

        for (int i = 0; i < 120; i++)
        {
            if (authTask.IsCompleted)
                break;
            yield return null;
        }

        while (!authTask.IsCompleted)
        {
            if (EditorUtility.DisplayCancelableProgressBar(_page, "Waiting for authentication...", 0.0f))
            {
                EditorUtility.ClearProgressBar();
                Debug.LogWarning("Import cancelled by the user");
                yield break;
            }
            yield return null;
        }

        UserCredential credential = authTask.Result;
        
        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Unity Config Importer",
        });

        var request = service.Spreadsheets.Values.Get(_sheetId, _page);
        var requestTask = request.ExecuteAsync();

        while (!requestTask.IsCompleted)
        {
            /*if (EditorUtility.DisplayCancelableProgressBar(_page, "Downloading data...", 0.15f))
            {
                EditorUtility.ClearProgressBar();
                Debug.LogWarning("Import cancelled by the user");
                yield break;
            }*/
            yield return null;
        }

        var response = requestTask.Result;
        var values = response.Values;


        if (EditorUtility.DisplayCancelableProgressBar(_page, "Processing data...", 0.3f))
        {
            EditorUtility.ClearProgressBar();
            Debug.LogWarning("Import cancelled by the user");
            yield break;
        }

        var processTask = ProcessData(values);

        while (!processTask.IsCompleted)
            yield return null;

        try
        {
            processTask.Wait();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            EditorUtility.ClearProgressBar();
            EditorUtility.DisplayDialog("Error", "Import failed!", "OK");
            yield break;
        }

        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("Done", "Import was successful!", "OK");
    }

    private async Task ProcessData(IList<IList<object>> values)
    {
        if (values.Count < 1)
            throw new Exception("Missing localization data.");
        if (values[0].Count < 1)
            throw new Exception("Missing localization data header.");
        if (values[0][0].ToString() != "ID")
            throw new Exception("Invalid localization data header.");

        var langSet = new HashSet<string>();
        var languages = new List<string>();

        for (int i = 1; i < values[0].Count; i++)
        {
            var language = values[0][i].ToString();
            if (langSet.Add(language))
                languages.Add(language);
            else
                Debug.LogError($"duplicate language id found {language}");
        }

        var dict = new Dictionary<string, Dictionary<string, string>>();

        for (int row = 1; row < values.Count; row++)
        {
            await Progress((float)row / values.Count);
            if (values[row].Count == 0)
                continue;       
            
            var rowDict = new Dictionary<string, string>();

            var lang = "";

            for (int col = 1; col < values[row].Count; col++)
            {
                lang = languages[col - 1];
                var str = values[row][col].ToString();
                var stringID = values[row][0].ToString();

                if (stringID == "")
                    continue;

                if (!dict.ContainsKey(lang))
                {
                    dict.Add(lang, new Dictionary<string, string>());
                }

                if (dict[lang].ContainsKey(stringID))
                    throw new Exception($"Duplicate string ID \"{stringID}\".");
                else
                    dict[lang].Add(stringID, str);
            }
        }

        var asset = ScriptableObject.CreateInstance<LocalizationData>();
        asset.LocalizationValues = dict;
        AssetDatabase.CreateAsset(asset, LocalizationData.AssetPath);
        AssetDatabase.SaveAssets();
    }

    protected Task Progress(float progress)
    {
        if (EditorUtility.DisplayCancelableProgressBar(_page, "Processing data...", 0.3f + progress * 0.7f))
            throw new Exception("aborted");
        return Task.CompletedTask;
    }

    [MenuItem("Tools/Import Localizations", false, 1100)]
    static void Import()
    {
        EditorCoroutineUtility.StartCoroutineOwnerless(new LocalizationsLoader().DoImport());
    }
}
