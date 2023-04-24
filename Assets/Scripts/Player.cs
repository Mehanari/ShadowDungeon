using UnityEngine;
using UnityEngine.Events;

public class Player : Creature
{
    public static Player Instance;
    [SerializeField] private UnityEvent _onLose;
    [SerializeField] private string _highScoreTag;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Lose()
    {
        _onLose?.Invoke();
        Debug.Log("Lose");
        int highScore = PlayerPrefs.GetInt(_highScoreTag, 0);
        int currentScore = GameSessionData.Instance.Score;
        if (highScore < currentScore)
        {
            PlayerPrefs.SetInt(_highScoreTag, currentScore);
        }
    }
}
