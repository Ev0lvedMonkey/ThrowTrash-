using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> TransferLevelNumberEvent = new();
    public static UnityEvent<int> SaveLevelNumberEvent = new();
    public static UnityEvent TransferNewThrowEvent = new();
    public static UnityEvent RestartLevelEvent = new();
    public static UnityEvent UpdateCurrentLevelNumberEvent = new();
    public static UnityEvent LoadNextLevelEvent = new();
    public static UnityEvent LastChanceEvent = new();

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

    public static void InvokeLastChance() =>
        LastChanceEvent.Invoke();

    public static void InvokeLoadNextLevel() =>
        LoadNextLevelEvent.Invoke();
}
