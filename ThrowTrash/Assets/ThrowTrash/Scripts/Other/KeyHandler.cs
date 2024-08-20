using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyHandler : MonoBehaviour
{
    private const string GAME_SCENE = "GameScene";
    private void Update()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadScene(GAME_SCENE);
    }
}
