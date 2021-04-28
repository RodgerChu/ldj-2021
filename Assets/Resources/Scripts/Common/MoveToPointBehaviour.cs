using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MoveToPointBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    [SerializeField] private float _transitionDuration = 2f;
    [SerializeField] private float _delayTime = 3f;

    [Space]
    [SerializeField] private bool _cycleMoving;

    [Space]
    [SerializeField] private UnityEvent _onLastPointReached;

    [SerializeField] private FootstepsSoundsPlayer _soundsPlayer;

    private void Start()
    {
        StartCoroutine(MoveCoroutine());
        _soundsPlayer?.Play();
    }

    private void MoveToPoint(Transform point)
    {
        transform.DOMove(point.position, _transitionDuration);
    }

    private IEnumerator MoveCoroutine()
    {
        var pointIndex = 0;

        while (true)
        {
            var point = _waypoints[pointIndex];                

            MoveToPoint(point);

            yield return new WaitForSeconds(_transitionDuration);
            yield return new WaitForSeconds(_delayTime);

            pointIndex++;
            if (pointIndex >= _waypoints.Length)
            {
                _onLastPointReached?.Invoke();
                if (!_cycleMoving)
                    yield break;

                pointIndex = 0;
            }
        }
    }
}