using System.Collections.Generic;
using UnityEngine;

public class UILevelNumberAssignment : MonoBehaviour
{
    [SerializeField] private bool _updateList;
    [SerializeField] private List<UITextImage> _levelsList;

    private void OnValidate()
    {
        if (_updateList)
            UpdateList();
    }

    private void UpdateList()
    {
        _levelsList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetChild(0).TryGetComponent(out UITextImage text))
                _levelsList.Add(text);
        }
        try
        {
            for (int i = 0; i < _levelsList.Count; i++)
            {
                if (_levelsList[i] == null)
                    _levelsList.RemoveAt(i);
                _levelsList[i].SetNumber(i + 1);
            }
        }
        catch
        {
            return;
        }
    }
}
