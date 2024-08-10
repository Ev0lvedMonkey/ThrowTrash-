using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> TransferLevelNumberEvent = new();
    public static UnityEvent<int> SaveLevelNumberEvent = new();
    public static UnityEvent TransferNewThrowEvent = new();
    public static UnityEvent RestartLevelEvent = new();
    public static UnityEvent UpdateCurrentLevelNumberEvent = new();

    //todo 
    public static UnityEvent OpenWinPopUpEvent = new();
    public static UnityEvent CloseWinPopUpEvent = new();
    public static UnityEvent OpenLevelsListCanvasEvent = new();
    public static UnityEvent CloseLevelsListCanvasEvent = new();


    public static void InvokeLoadLevel(int levelNumber) =>
        TransferLevelNumberEvent.Invoke(levelNumber);

    public static void InvokeSaveLevel(int levelNumber) =>
        SaveLevelNumberEvent.Invoke(levelNumber);

    public static void InvokeTransferNewThrow() =>
        TransferNewThrowEvent.Invoke();

    public static void InvokeRestartLevel() =>
        RestartLevelEvent.Invoke(); 
    
    public static void InvokeUpdateCurrentLevel() =>
        UpdateCurrentLevelNumberEvent.Invoke();

    public static void InvokeOpenWinPopUp() =>
        OpenWinPopUpEvent.Invoke();

    public static void InvokeCloseWinPopUp() =>
        CloseWinPopUpEvent.Invoke();
    
    public static void InvokeOpenLevels() =>
        OpenLevelsListCanvasEvent.Invoke();

    public static void InvokeCloseLevels() =>
        CloseLevelsListCanvasEvent.Invoke();

}
