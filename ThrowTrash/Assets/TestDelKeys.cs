using UnityEngine;

public class TestDelKeys : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("del all ");
        }
    }
}
