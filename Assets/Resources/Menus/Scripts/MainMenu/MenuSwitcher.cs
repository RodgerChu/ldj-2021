using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _transitionSplashScreen;
    private void Awake() 
    {
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
        _transitionSplashScreen.SetActive(false);
    }

    public void SwitchOnOptionsMenu()
    {
        StartTransitionSplashScreen();
        _optionsMenu.SetActive(true);
        EndTransitionSplashScreen();
    }

    public void SwitchOffOptionsMenu()
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
