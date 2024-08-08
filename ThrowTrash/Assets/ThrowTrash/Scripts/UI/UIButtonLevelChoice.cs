using UnityEngine;

public class UIButtonLevelChoice : MonoBehaviour
{
    [SerializeField] private Canvas _levelsGridCanvas;
    [SerializeField] private UITextImage _levelNubmer;

    private void OnValidate()
    {
        if(_levelNubmer == null)
            _levelNubmer = transform.GetChild(0).GetComponent<UITextImage>();
    }

    public void LoadLevel()
    {
        Debug.Log("Like a destroy");
        _levelsGridCanvas.gameObject.SetActive(false);
        EventManager.InvokeLoadLevel(_levelNubmer.GetLevelNumber());
    }
}
