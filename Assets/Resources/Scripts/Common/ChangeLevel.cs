using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private int _nextLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            SceneManager.LoadScene(_nextLevel);
        }
    }
}
