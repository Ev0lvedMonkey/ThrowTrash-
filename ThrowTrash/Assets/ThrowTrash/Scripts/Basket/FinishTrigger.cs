using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private bool _isLastFinish;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BallMovement ball))
        {
            if (!_isLastFinish)
            {
                DialogManager.ShowDialog<WinDialog>();
                EventManager.InvokeUpdateCurrentLevel();
            }
            else
                DialogManager.ShowDialog<LastWinDialog>();
        }
    }
}

