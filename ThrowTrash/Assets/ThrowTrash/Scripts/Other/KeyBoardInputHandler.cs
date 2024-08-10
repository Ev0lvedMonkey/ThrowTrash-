using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyBoardInputHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
            SceneManager.LoadScene(1);
    }
}
