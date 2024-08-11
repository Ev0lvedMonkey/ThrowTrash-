using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBallMove : MonoBehaviour
{
    [SerializeField] private List<Transform> _shotPositions;
    [SerializeField] private Rigidbody2D _trash;
    [SerializeField] private float _durationTime;
    [SerializeField] private float _force;

    private void OnEnable()
    {
        Run();
    }

    private void Run()
    {
        Sequence sequence = DOTween.Sequence();

        foreach (var item in _shotPositions)
            sequence.Append(CreateJumpTween(item.position));

        sequence.SetLoops(-1);
    }

    private Tween CreateJumpTween(Vector3 position)
    {
        return _trash.DOJump(position, _force, 1, _durationTime)
            .OnStepComplete(() => Rotate(position));
    }

    private void Rotate(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - _trash.transform.position).normalized;

        float rotationDirection = direction.x > 0 ? 180f : -180f;

        _trash.transform
            .DORotate(new Vector3(0, 0, _trash.transform.rotation.z + rotationDirection), _durationTime, RotateMode.FastBeyond360);
    }
}
