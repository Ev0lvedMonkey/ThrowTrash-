using UnityEngine;
using UnityEngine.Events;

public class AnyKeyHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent OnKeyPressed;

    private void Update()
    {
        if (Input.anyKeyDown)
            OnKeyPressed.Invoke();
    }
}
