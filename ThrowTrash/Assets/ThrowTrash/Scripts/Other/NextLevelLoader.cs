using UnityEngine;

public class NextLevelLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        EventManager.InvokeCloseWinPopUp();
        EventManager.InvokeLoadNextLevel();
    }
}
