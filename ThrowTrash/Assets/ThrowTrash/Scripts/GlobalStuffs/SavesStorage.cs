using UnityEngine;
using YG;

public class SavesStorage : MonoBehaviour
{
    private const string LevelsNumber = "LevelsNumber";
    private const int TotalMaxLevel = 21;
    private const int MinLevelNumber = 1;

    public static int MaxLevelPP { get; private set; }
    public int MaxLevelYG { get; private set; }

    public void Init()
    {
        //todo bootstrap
        EventManager.SaveLevelNumberEvent.AddListener(UpdateSavedData);
        InitSavedData();
        Debug.Log($"save storage init");
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += InitSavedData;   
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= InitSavedData;   
    }

    public static int GetTotalMaxLevel()
    {
        return TotalMaxLevel;
    }

    private void UpdateSavedData(int outLevelNumber)
    {
        if (outLevelNumber < 0 || outLevelNumber > TotalMaxLevel)
            return;
        if (MaxLevelPP > outLevelNumber)
            return;

        MaxLevelPP = outLevelNumber;
        MaxLevelYG = MaxLevelPP;
        YandexGame.savesData.maxLevelNumber = MaxLevelYG;
        YandexGame.SaveProgress();
        PlayerPrefs.SetInt(LevelsNumber, MaxLevelPP);
    }

    private void InitSavedData()
    {
        if (!PlayerPrefs.HasKey(LevelsNumber))
            PlayerPrefs.SetInt(LevelsNumber, MinLevelNumber);
        MaxLevelPP = PlayerPrefs.GetInt(LevelsNumber);

        MaxLevelYG = YandexGame.savesData.maxLevelNumber;

        Debug.Log($"{MaxLevelPP} || {MaxLevelYG}");

        int bestScore = Mathf.Max(MaxLevelYG, MaxLevelPP);

        MaxLevelYG = bestScore;
        MaxLevelPP = bestScore;
        Debug.Log($"After {MaxLevelPP} || {MaxLevelYG}");
    }
}
