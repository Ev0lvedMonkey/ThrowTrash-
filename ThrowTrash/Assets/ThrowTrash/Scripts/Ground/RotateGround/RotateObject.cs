using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private enum RotateDirection { Right, Left }

    [SerializeField, Range(0.5f,5)] private float _rotateSpeed;
    [SerializeField] private RotateDirection _direction;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float direction = _direction == RotateDirection.Left ? -1 : 1;
        float zAxisRotation = direction * _rotateSpeed;
        gameObject.transform.Rotate(0, 0, zAxisRotation);
    }
}
