using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PolygonCollider2D))]
public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private bool _isLastFinish;
    [SerializeField] private UnityEvent OnTrigger;

    private void OnValidate()
    {
        if(!_isLastFinish)
            OnTrigger.RemoveAllListeners();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BallMovement ball))
        {
            if (!_isLastFinish)
            {
                EventManager.InvokeOpenWinPopUp();
                EventManager.InvokeUpdateCurrentLevel();
            }
            else
            {
                OnTrigger.Invoke();
                Debug.Log("workerd");
            }
        }
    }
}

