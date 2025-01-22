using UnityEngine;
using UnityEngine.UI;

public class MenuDialog : Dialog, ISinglRepresentative
{
    [SerializeField] private Button _menuIcon;
    [SerializeField] private Button _restartIcon;

    private static MenuDialog Instance;

    private void Awake()
    {
        UseSinglRepresentative();
        InitDialogButtonsLiseners();
    }

    public void HideDialog()
    {
        base.Hide();
    }

    protected void InitDialogButtonsLiseners()
    {
        base.InitButtonsLiseners();
        _menuIcon?.onClick.AddListener(() =>
        {
            DialogManager.ShowDialog<MenuDialog>();
        });
        _restartIcon?.onClick.AddListener(() => 
        {
            EventManager.InvokeRestartLevel();
            HideDialog();
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
            HideDialog();
            Debug.Log($"Destroed after instance {this.name}");
        }
    }
}
