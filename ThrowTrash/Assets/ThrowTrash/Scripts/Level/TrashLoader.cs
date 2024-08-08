using UnityEngine;

public class TrashLoader : ObjectLoader
{
    [SerializeField] private Transform _spawnPoint;

    private const string ResourcesTrashPath = "Prefabs/Trash";

    private GameObject _trash;

    private void OnValidate()
    {
        if (_spawnPoint == null)
            throw new System.Exception($"{gameObject.name} не имеет точку появления");
    }

    private void OnEnable()
    {
        SpawnObject(ResourcesTrashPath,out _trash, _spawnPoint.position);
    }

    private void OnDisable()
    {
        RemoveObject(_trash);
    }

    protected override void RemoveObject(GameObject currentObject)
    {
        base.RemoveObject(currentObject);
    }

    protected override void SpawnObject(string path,out GameObject currentObject, Vector3 spawnPosition)
    {
        base.SpawnObject(path, out currentObject, spawnPosition);
    }
}
