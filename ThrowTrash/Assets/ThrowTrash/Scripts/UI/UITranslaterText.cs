using TMPro;
using UnityEngine;
using YG;

public class UITranslaterText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enText;
    [SerializeField] private TextMeshProUGUI _ruText;

    private const string English = "en";
    private const string Russian = "ru";


    private void OnValidate()
    {
        if (_enText == null)
            _enText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (_ruText == null)
            _enText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        DetermineTextLanguage();
    }

    private void DetermineTextLanguage()
    {
        if (YandexGame.lang == English)
        {
            _ruText.gameObject.SetActive(false);
            _enText.gameObject.SetActive(true);
        }
        if (YandexGame.lang == Russian)
        {
            _enText.gameObject.SetActive(false);
            _ruText.gameObject.SetActive(true);
        }
    }
}
