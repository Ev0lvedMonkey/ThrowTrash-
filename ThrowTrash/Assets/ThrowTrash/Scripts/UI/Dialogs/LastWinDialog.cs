using UnityEngine;

public class LastWinDialog : Dialog, ISinglRepresentative
{
    private static LastWinDialog Instance;

    private void Awake()
    {
        UseSinglRepresentative();
    }

    public void UseSinglRepresentative()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log($"Insance {this.name}");
        }
        else
        {
            Hide();
            Debug.Log($"Destroed after instance {this.name}");
        }
    }
}
