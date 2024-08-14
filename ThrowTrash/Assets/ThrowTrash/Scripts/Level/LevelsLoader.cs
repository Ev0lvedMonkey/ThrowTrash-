using UnityEngine;
using YG;

public class LevelsLoader : ObjectLoader
{
    private const string ResourcesLevelPath = "Prefabs/LevelPrefabs/Level";

    private GameObject _currentLevel;
    private Vector3 SpawnPoint = new(3.45f, -3.43f, 0);
    private int _currentLevelNumber;

    protected override void RemoveObject(GameObject currentObject)
    {
        base.RemoveObject(currentObject);
    }

    protected override void SpawnObject(string path, out GameObject currentObject, Vector3 spawnPosition)
    {
        base.SpawnObject(path, out currentObject, spawnPosition);
    }

    public void Init()
    {
        EventManager.TransferLevelNumberEvent.AddListener(LoadLevel);
        EventManager.RestartLevelEvent.AddListener(RestartLevel);
        EventManager.UpdateCurrentLevelNumberEvent.AddListener(SaveNewMaxLevelNumber);
        EventManager.LoadNextLevelEvent.AddListener(LoadNextLevel);
    }

    private void LoadLevel(int levelNumber)
    {
        _currentLevelNumber = levelNumber;
        string fullLevelPath = ResourcesLevelPath + _currentLevelNumber;
        Debug.Log($"{fullLevelPath} loaded");
        SpawnObject(fullLevelPath, out _currentLevel, SpawnPoint);
    }

    private void RestartLevel()
    {
        RemoveObject(_currentLevel);
        LoadLevel(_currentLevelNumber);
    }

    private void LoadNextLevel()
    {
        RemoveObject(_currentLevel);
        _currentLevelNumber++;
        string fullLevelPath = ResourcesLevelPath + _currentLevelNumber;
        SpawnObject(fullLevelPath, out _currentLevel, SpawnPoint);
        YandexGame.FullscreenShow();
    }

    private void SaveNewMaxLevelNumber()
    {
        EventManager.InvokeSaveLevel(_currentLevelNumber + 1);
    }
}
