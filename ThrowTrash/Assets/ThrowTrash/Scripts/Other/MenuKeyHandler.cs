using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MenuKeyHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private UnityEvent _onKeyDown;

    [Header("Handler property")]
    [SerializeField] private bool _useEvent;

    private void Update()
    {
        if (_useEvent)
            UseEvent();
        OpenMenu();
    }

    private void OpenMenu()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            DialogManager.ShowDialog<MenuDialog>();
            return;
        }
    }

    private void UseEvent()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            _onKeyDown.Invoke();
            return;
        }
    }
}
