using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SceneLoader : MonoBehaviour
{
    private enum ScenesCollection
    {
        MenuScene,
        GameScene
    };

    [SerializeField] private ScenesCollection selectedScene;

    public void LoadNewScene()
    {
        SceneManager.LoadScene(selectedScene.ToString());
        YandexGame.FullscreenShow();
    }

}
