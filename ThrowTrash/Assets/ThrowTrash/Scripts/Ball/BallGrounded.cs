using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class BallGrounded : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out GroundFlag ground))
            IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out GroundFlag ground))
            IsGrounded = false;
    }

    private void Update()
    {
        //Debug.Log($"{IsGrounded}");
    }
}
