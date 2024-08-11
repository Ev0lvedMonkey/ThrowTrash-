using UnityEngine;

public class WinPopUpLoader : ObjectLoader
{
    private const string ResourcesLevelsListPath = "Prefabs/UiElements/FullParts/WinPopUp";

    private GameObject _popUpCanvas;

    private void Awake()
    {
        //todo bootstrap
        Init();
    }

    private void Init()
    {
        EventManager.OpenWinPopUpEvent.AddListener(SpawnCanvas);
        EventManager.CloseWinPopUpEvent.AddListener(RemoveCanvas);
    }

    private void SpawnCanvas()
    {
        SpawnObject(ResourcesLevelsListPath, out _popUpCanvas, Vector3.zero);
    }

    private void RemoveCanvas()
    {
        RemoveObject(_popUpCanvas);
    }

    protected override void SpawnObject(string path, out GameObject currentObject, Vector3 spawnPosition)
    {
        base.SpawnObject(path, out currentObject, spawnPosition);
    }

    protected override void RemoveObject(GameObject currentObject)
    {
        base.RemoveObject(currentObject);
    }
}

