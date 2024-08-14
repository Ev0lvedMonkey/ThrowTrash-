using UnityEngine;

public abstract class ObjectLoader : MonoBehaviour
{
    protected virtual void SpawnObject(string path, out GameObject currentObject, Vector3 spawnPosition)
    {
        currentObject = Resources.Load<GameObject>(path);
        if (currentObject == null)
        {
            Debug.LogError($"Object not load\nPath {path}");
            return;
        }
        currentObject = Instantiate(currentObject, spawnPosition, Quaternion.identity);
    }

    protected virtual void RemoveObject(GameObject currentObject) 
    {
        Destroy(currentObject.gameObject);
        Resources.UnloadUnusedAssets();
    }
}
