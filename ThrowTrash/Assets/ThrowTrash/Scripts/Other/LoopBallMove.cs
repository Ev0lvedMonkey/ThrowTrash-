using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBallMove : MonoBehaviour
{
    [SerializeField] private List<Transform> _shotPositions;
    [SerializeField] private Rigidbody2D _trash;
    [SerializeField] private float _durationTime;
    [SerializeField] private float _force;

    private const int RightBottom = 0;
    private const int RightTop = 1;
    private const int LeftBottom = 2;
    private const int LeftTop = 3;

    private void OnEnable()
    {
        Run();
    }

    private void Run()
    {
        DOTween.Sequence().Append(_trash.DOJump(_shotPositions[LeftTop].position, _force, 1, _durationTime))
           .Append(_trash.DOJump(_shotPositions[RightTop].position, _force, 1, _durationTime))
           .Append(_trash.DOJump(_shotPositions[LeftBottom].position, _force, 1, _durationTime))
           .Append(_trash.DOJump(_shotPositions[RightBottom].position, _force, 1, _durationTime))
            .SetLoops(-1);
    }
}
