using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private BallGrounded _ballGrounded;
    [SerializeField] private ShotTrajectory _trajectory;

    private const float _maxDistance = 9;
    private const float _rotationSpeed = 12;
    private const float _shootForce = 2f;
    private const float leftRotationDirection = -1f;

    private const KeyCode LMB = KeyCode.Mouse0;
    private readonly Color WhiteColor = Color.white;
    private readonly Color BlackColor = Color.black;

    private void OnValidate()
    {
        if (_rb == null)
            _rb = GetComponent<Rigidbody2D>();
        if (_ballGrounded == null)
            _ballGrounded = GetComponent<BallGrounded>();
        if (_trajectory == null)
            _trajectory = GetComponent<ShotTrajectory>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void Update()
    {
        Move(GetMouseWorldPosition() - transform.position);
    }

    private void Move(Vector2 shootDirection)
    {
        if (!CanMouseInput())
            return;

        DrawTrajectory(shootDirection);

        if (Input.GetKeyUp(LMB))
        {
            _rb.AddForce(shootDirection * _shootForce, ForceMode2D.Impulse);
            Twist(shootDirection);
            EventManager.InvokeTransferNewThrow();
        }
    }

    private void Twist(Vector2 shootDirection)
    {
        if (shootDirection.x > transform.position.x)
            _rb.AddTorque(leftRotationDirection * _rotationSpeed);
        else
            _rb.AddTorque(_rotationSpeed);
    }

    private bool CanMouseInput()
    {
        //Debug.Log($"111 Distanse {Vector2.Distance(GetMouseWorldPosition(), transform.position)}");

        if (_ballGrounded.IsGrounded == false
            || GetMouseWorldPosition().y < transform.position.y
            || Vector2.Distance(GetMouseWorldPosition(), transform.position) > _maxDistance)
        {
            _trajectory.SetNewColor(BlackColor);
            return false;
        }
        else
        {
            _trajectory.SetNewColor(WhiteColor);
            return true;
        }
    }

    private void DrawTrajectory(Vector2 shootDirection)
    {
        Vector2 objectSpeed = shootDirection * _shootForce;
        if (Input.GetKey(LMB) && _ballGrounded.IsGrounded)
        {
            _trajectory.TrajectoryEnable();
            _trajectory.Draw(transform.position, objectSpeed);
        }

        if (Input.GetKeyUp(LMB))
            _trajectory.TrajectoryDisable();
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
