using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class LoopBallMove : MonoBehaviour
{
    [SerializeField] private List<Transform> _shotPositions;
    [SerializeField] private Rigidbody2D _trash;
    [SerializeField] private float _durationTime;
    [SerializeField] private float _force;

    private Sequence _sequence;

    private void OnEnable()
    {
        Run();
    }

    private void OnDisable()
    {
        StopRun();
    }

    private void Run()
    {
        _sequence = DOTween.Sequence();

        foreach (var item in _shotPositions)
            _sequence.Append(CreateJumpTween(item.position));

        _sequence.SetLoops(-1);
    }

    private void StopRun()
    {
        _sequence?.Kill(); 
        _sequence = null;
    }

    private Tween CreateJumpTween(Vector3 position)
    {
        return _trash.DOJump(position, _force, 1, _durationTime)
            .OnStepComplete(() => Rotate(position));
    }

    private void Rotate(Vector3 targetPosition)
    {
        if (_trash == null)
            return;
        Vector3 direction = (targetPosition - _trash.transform.position).normalized;

        float rotationDirection = direction.x > 0 ? 180f : -180f;

        _trash.transform
            .DORotate(new Vector3(0, 0, _trash.transform.rotation.z + rotationDirection), _durationTime, RotateMode.FastBeyond360);
    }
}
