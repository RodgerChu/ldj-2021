using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonFlipper : MonoBehaviour
{
    [SerializeField] List<Transform> _transformToFlip;
    [SerializeField] List<SpriteRenderer> _srToFlip;
    public void SetFlip(float directionX)
    {
        if (_transformToFlip != null)
        {
            foreach (var transform in _transformToFlip)
            {
                var currentPosition = transform.localPosition;
                currentPosition.x = Mathf.Abs(currentPosition.x) * directionX;
                transform.localPosition = currentPosition;
            }
        }

        if (_srToFlip != null)
        {
            foreach (var sr in _srToFlip)
            {
                bool flipX = sr.flipX;
                flipX = (directionX < 0f) ? true : false;
                sr.flipX = flipX;
            }
        }
    }
}
