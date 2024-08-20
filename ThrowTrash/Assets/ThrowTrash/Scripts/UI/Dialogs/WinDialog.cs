using UnityEngine;
using UnityEngine.UI;

public class WinDialog : Dialog, ISinglRepresentative
{
    [SerializeField] private Button _loadNewLevelButton;

    private static WinDialog Instance;


    private void Awake()
    {
        UseSinglRepresentative();
        InitButtonsLiseners();
    }

    protected void InitButtonsLiseners()
    {
        base.InitButtonsLiseners();
        _loadNewLevelButton?.onClick.AddListener(() =>
        {
            EventManager.InvokeLoadNextLevel();
            Hide();
        });
    }

    public void UseSinglRepresentative()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log($"Insance {this.name}");
        }
        else
        {
            Hide();
            Debug.Log($"Destroed after instance {this.name}");
        }
    }
}
