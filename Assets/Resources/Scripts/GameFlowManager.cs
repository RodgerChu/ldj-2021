using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerLightController _playerLightController;
    [SerializeField] private Transform _checkpoint;
    [SerializeField] private DeathScreenAnimator _animator;
    [SerializeField] private Button _restartButton;

    private void Start()
    {
        _playerLightController.OnLightFaded += OnLightFaded;
        _restartButton.onClick.AddListener(Restart);
    }

    private void OnLightFaded()
    {
        _animator.Show();
    }

    private void Restart()
    {
        _player.transform.position = _checkpoint.position;
        _playerLightController.ResetLight();
        _animator.Hide();
    }
}
