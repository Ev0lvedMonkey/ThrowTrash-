using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Dialog : MonoBehaviour
{
    [SerializeField] private Button _homeButton;

    private const string MENU_SCENE = "MenuScene";


    private void Awake()
    {
        InitButtonsLiseners();
    }

    protected void InitButtonsLiseners()
    {
        _homeButton?.onClick.AddListener(LoadHomeScene);
    }

    protected void Hide()
    {
        Destroy(gameObject);
    }

    private void LoadHomeScene()
    {
        SceneManager.LoadScene(MENU_SCENE);
        Hide();
    }

}