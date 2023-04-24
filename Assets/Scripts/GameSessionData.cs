using UnityEngine;
using UnityEngine.Events;

public class GameSessionData : MonoBehaviour
{
    public UnityEvent OnScoreChanged;

    private int _score;

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            OnScoreChanged?.Invoke();
        }
    }

    public static GameSessionData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ResetSession()
    {
        Score = 0;
    }
}
