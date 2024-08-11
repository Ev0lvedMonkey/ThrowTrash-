using UnityEngine;

public class AnyKeyHandler : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;

    private void OnValidate()
    {
        if(_sceneLoader == null)
            _sceneLoader = GetComponent<SceneLoader>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
            _sceneLoader.LoadNewScene();
    }
}
