using UnityEngine;

[RequireComponent(typeof(LevelsLoader))]
public class ThrowСounter : MonoBehaviour
{
    public int ThrowCount
    {
        get
        {
            if (_throwСount >= MaxThrowСount)
            {
                _throwСount = 0;
                EventManager.InvokeLastChance();
                return _throwСount;
            }
            if (_throwСount < 0)
            {
                _throwСount = 0;
                return _throwСount;
            }
            return _throwСount;
        }
        private set => _throwСount = value;
    }

    private const int MaxThrowСount = 3;

    private int _throwСount;

    public void Init()
    {
        EventManager.TransferNewThrowEvent.AddListener(AuthNewThrow);
    }

    private void AuthNewThrow()
    {
        ThrowCount++;
    }
}
