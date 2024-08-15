using UnityEngine;
using UnityEngine.Events;

public class KeyHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent OnAnyKeyPressed;

    private void Update()
    {
        if (Input.anyKeyDown)
            OnAnyKeyPressed.Invoke();
    }
}
