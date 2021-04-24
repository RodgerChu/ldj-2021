using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _transitionSplashScreen;

    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _exitOptionsButton;

    private void Awake() 
    {
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
        _transitionSplashScreen.SetActive(false);
    }

    private void Start()
    {
        _startGameButton.onClick.AddListener(StartTransitionSplashScreen);
        _optionsButton.onClick.AddListener(SwitchOnOptionsMenu);
        _exitOptionsButton.onClick.AddListener(SwitchOffOptionsMenu);
    }

    private void SwitchOnOptionsMenu()
    {
        StartTransitionSplashScreen();
        _optionsMenu.SetActive(true);
        EndTransitionSplashScreen();
    }

    private void SwitchOffOptionsMenu()
    {
        StartTransitionSplashScreen();
        _optionsMenu.SetActive(false);
        EndTransitionSplashScreen();
    }

    private void StartTransitionSplashScreen()
    {
        _transitionSplashScreen.SetActive(true);
    }

    private void EndTransitionSplashScreen()
    {
        _transitionSplashScreen.SetActive(false);
    }
}
