using UnityEngine;

public abstract class ObjectLoader : MonoBehaviour
{
    protected virtual void SpawnObject(string path, out GameObject currentObject, Vector3 spawnPosition)
    {
        GameObject levelPrefab = Resources.Load<GameObject>(path);
        currentObject = Instantiate(levelPrefab, spawnPosition, Quaternion.identity);
    }

    protected virtual void RemoveObject(GameObject currentObject) 
    {
        Destroy(currentObject.gameObject);
        Resources.UnloadUnusedAssets();
    }
}
