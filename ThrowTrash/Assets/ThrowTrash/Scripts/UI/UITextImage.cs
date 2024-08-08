using UnityEngine;
using UnityEngine.UI;

public class UITextImage : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void OnValidate()
    {
        if(_text == null)
            _text = GetComponent<Text>();
        if(!char.IsDigit(_text.text, 0))
        {
            _text.text = "0";
            Debug.Log($"{transform.parent.name} was text");
        }
    }

    public int GetLevelNumber()
    {
        if(int.TryParse(_text.text, out int number))
            return number;
        else return 0;  
    }

    public void SetNumber(int number)
    {
        _text.text = "";
        _text.text = $"{number}";
    }
}
