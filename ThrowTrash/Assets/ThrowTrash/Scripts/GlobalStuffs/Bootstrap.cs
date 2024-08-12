using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SavesStorage _storage;
    [SerializeField] private Throw—ounter _throw—ounter;
    [SerializeField] private LevelsLoader _levelsLoader;
    [SerializeField] private WinPopUpLoader _winPopUpLoader;
    [SerializeField] private LevelsListLoader _levelsListLoader;

    private void Awake()
    {
        _storage.Init();
        _throw—ounter.Init();
        _levelsLoader.Init();
        _winPopUpLoader.Init();
        _levelsListLoader.Init();   
    }
}
