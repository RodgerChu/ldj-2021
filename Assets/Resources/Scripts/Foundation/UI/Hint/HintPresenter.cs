using Foundation.UI.Localization;
using UnityEngine;

namespace Foundation.UI
{
    public class HintPresenter : AbstractService<IHintController>, IHintController
    {
        [SerializeField] private LocalizedTextWrapper _text;

        public void Show(string alias)
        {
            _text.SetLocalizationKey(alias);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
