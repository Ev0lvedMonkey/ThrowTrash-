using UnityEngine;

public class UISelfLoader : ObjectLoader
{
    [SerializeField] private string SelfPath = "Prefabs/UiElements/FullParts/";

    private GameObject _object;

    public void LoadSelf()
    {
        SpawnObject(SelfPath + gameObject.name, out _object, Vector3.zero);
    }

    public void RemoveSelf()
    {
        RemoveObject(gameObject);
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
