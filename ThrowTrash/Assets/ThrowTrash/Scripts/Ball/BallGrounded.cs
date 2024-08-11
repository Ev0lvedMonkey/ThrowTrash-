using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class BallGrounded : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    private bool _isLastChance;

    private void OnEnable()
    {
        Init();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out GroundFlag ground) && _isLastChance)
            EventManager.InvokeRestartLevel();
    }

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

    private void Init()
    {
        EventManager.RestartLevelEvent.AddListener(DeactivateLastChance);
        EventManager.LastChanceEvent.AddListener(ActivateLastChance);
    }

    private void ActivateLastChance() =>
        _isLastChance = true;

    private void DeactivateLastChance() =>
        _isLastChance = false;
}
