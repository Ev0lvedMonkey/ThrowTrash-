using UnityEngine;
using UnityEngine.UI;

public class UIButtonLevelChoice : MonoBehaviour
{
    [SerializeField] private Canvas _levelsGridCanvas;

    [SerializeField] private UITextImage _levelNubmer;
    [SerializeField] private Button _levelButton;
    [SerializeField] private GameObject _blockImageObject;

    private void OnValidate()
    {
        if (_levelNubmer == null)
            _levelNubmer = transform.GetChild(0).GetComponent<UITextImage>();
        if (_blockImageObject == null)
            _blockImageObject = transform.GetChild(1).gameObject;
        if (_levelButton == null)
            _levelButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (SavesStorage.MaxLevelPP < _levelNubmer.GetLevelNumber())
            CloseAccessToLevel();
        else
            OpenAccessToLevel();
    }

    public void LoadLevel()
    {
        EventManager.InvokeLoadLevel(_levelNubmer.GetLevelNumber());
        EventManager.InvokeCloseLevels();
    }

    public void OpenAccessToLevel()
    {
        EnableLevelButton();
        DisableObject(_blockImageObject);
    }

    public void CloseAccessToLevel()
    {
        DisableLevelButton();
        EnableObject(_blockImageObject);
    }

    private void EnableObject(GameObject outObject)
    {
        outObject.SetActive(true);
    }

    private void DisableObject(GameObject outObject)
    {
        outObject.SetActive(false);
    }

    private void EnableLevelButton()
    {
        _levelButton.interactable = true;
    }

    private void DisableLevelButton()
    {
        _levelButton.interactable = false;
    }

}
