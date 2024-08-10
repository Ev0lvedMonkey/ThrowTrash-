using System;
using UnityEngine;

public class LevelsLoader : ObjectLoader
{
    private const string ResourcesLevelPath = "Prefabs/LevelPrefabs/Level";
    [SerializeField, Range(1, 3)] private int _testLevelNumber;

    private GameObject _currentLevel;
    private Vector3 SpawnPoint = new Vector3(3.45f, -3.43f, 0);
    private int _currentLevelNumber;

    private void Awake()
    {
        Init();
    }

    public void LoadLevel(int levelNumber)
    {
        _currentLevel = new GameObject();
        _currentLevelNumber = levelNumber;
        string fullLevelPath = ResourcesLevelPath + _currentLevelNumber;
        Debug.Log(fullLevelPath);
        SpawnObject(fullLevelPath, out _currentLevel, SpawnPoint);
    }

    public void RestartLevel()
    {
        RemoveObject(_currentLevel);
        LoadLevel(_currentLevelNumber);
    }

    protected override void RemoveObject(GameObject currentObject)
    {
        base.RemoveObject(currentObject);
    }

    protected override void SpawnObject(string path, out GameObject currentObject, Vector3 spawnPosition)
    {
        base.SpawnObject(path, out currentObject, spawnPosition);
    }

    private void Init()
    {
        EventManager.TransferLevelNumberEvent.AddListener(LoadLevel);
        EventManager.RestartLevelEvent.AddListener(RestartLevel);
        EventManager.UpdateCurrentLevelNumberEvent.AddListener(SaveNewMaxLevelNumber);
    }

    private void SaveNewMaxLevelNumber()
    {
        EventManager.InvokeSaveLevel(_currentLevelNumber + 1);
    }
}
