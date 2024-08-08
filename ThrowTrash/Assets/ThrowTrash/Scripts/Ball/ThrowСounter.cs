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
                EventManager.InvokeRestartLevel();
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

    [SerializeField] private LevelsLoader _levelsLoader;

    private const int MaxThrowСount = 3;

    private int _throwСount;

    private void OnValidate()
    {
        if (_levelsLoader == null)
            _levelsLoader = GetComponent<LevelsLoader>();
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        EventManager.TransferNewThrowEvent.AddListener(AuthNewThrow);
    }

    private void AuthNewThrow()
    {
        ThrowCount++;
    }
}
