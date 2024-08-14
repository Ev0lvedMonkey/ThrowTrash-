using TMPro;
using UnityEngine;
using YG;

public class UITextTranslater : MonoBehaviour
{
    public TextMeshProUGUI RuText;
    public TextMeshProUGUI EnText;

    private const string English = "en";
    private const string Russian = "ru";


    private void OnValidate()
    {
        if (EnText == null)
            EnText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (RuText == null)
            RuText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        DetermineTextLanguage(EnText,RuText);
    }

    public void DetermineTextLanguage(TextMeshProUGUI enText, TextMeshProUGUI ruText)
    {
        if (YandexGame.lang == English)
        {
            ruText.gameObject.SetActive(false);
            enText.gameObject.SetActive(true);
        }
        if (YandexGame.lang == Russian)
        {
            enText.gameObject.SetActive(false);
            ruText.gameObject.SetActive(true);
        }
    }
}
