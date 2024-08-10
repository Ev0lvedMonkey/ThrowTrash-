using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BallMovement ball))
        {
            EventManager.InvokeOpenWinPopUp();
            EventManager.InvokeUpdateCurrentLevel();
        }
    }
}
