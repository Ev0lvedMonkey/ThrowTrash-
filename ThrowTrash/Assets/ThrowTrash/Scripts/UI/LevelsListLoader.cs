using UnityEngine;

public class LevelsListLoader : ObjectLoader
{
    private const string ResourcesLevelsListPath = "Prefabs/UiElements/FullParts/LevelsListCanvas";

    private GameObject _LevelsListCanvas;

    private void Awake()
    {
        //todo bootstrap
        Init();
    }

    private void Start()
    {
        EventManager.InvokeOpenLevels();
    }

    private void Init()
    {
        EventManager.OpenLevelsListCanvasEvent.AddListener(SpawnCanvas);
        EventManager.CloseLevelsListCanvasEvent.AddListener(RemoveCanvas);
    }

    private void SpawnCanvas()
    {
        SpawnObject(ResourcesLevelsListPath, out _LevelsListCanvas, Vector3.zero);
    }

    private void RemoveCanvas()
    {
        RemoveObject(_LevelsListCanvas);
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

