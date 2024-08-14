using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(UITextTranslater))]
public class UITextRandomEncouragement : MonoBehaviour
{
    [SerializeField] private UITextTranslater _translater;

    [SerializeField] private TextMeshProUGUI _ruText;
    [SerializeField] private TextMeshProUGUI _enText;

    private readonly Dictionary<int, string> ruEncouragement = new Dictionary<int, string>() {
        { 1, "Круто!"},
        { 2, "Молодец!"},
        { 3, "Так держать!"},
    };

    private readonly Dictionary<int, string> enEncouragement = new Dictionary<int, string>() {
        { 1, "Cool!"},
        { 2, "Well done!"},
        { 3, "Awesome!"},
    };

    private void OnValidate()
    {
        if(_translater == null)
            _translater = GetComponent<UITextTranslater>();
        if (_enText == null)
            _enText = _translater.EnText;
        if (_ruText == null)
            _ruText = _translater.RuText;

    }

    private void OnEnable()
    {
        SetEncouragement();
    }

    private void SetEncouragement()
    {
        int textIndex = Random.Range(1, 4);
        _ruText.text = ruEncouragement[textIndex];
        _enText.text = enEncouragement[textIndex];
        _translater.DetermineTextLanguage(_enText, _ruText);
    }



}
