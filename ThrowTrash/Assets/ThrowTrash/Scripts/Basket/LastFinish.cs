using UnityEngine;
using UnityEngine.Events;

public class LastFinish : MonoBehaviour
{
    [SerializeField] private UnityEvent Trgiggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
