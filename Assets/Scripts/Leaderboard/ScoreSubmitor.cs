using UnityEngine;
using UnityEngine.Events;
using Dan.Main;

public class ScoreSubmitor : MonoBehaviour
{
    [SerializeField] private string _nameTag;
    [SerializeField] private string _scoreTag;
    [SerializeField] private UnityEvent _onSubmitSuccess;
    [SerializeField] private UnityEvent _onSubmitFailed;

    private string _pulicKey = "daf3b60a27e200465138ebda2a1c6acc49a985151969a9b1d038b9e89b12c4ca";

    public void SubmitScore()
    {
        string name = PlayerPrefs.GetString(_nameTag);
        int score = PlayerPrefs.GetInt(_scoreTag);
        if (string.IsNullOrEmpty(name))
        {
            _onSubmitFailed?.Invoke();
            return;
        }
        LeaderboardCreator.UploadNewEntry(_pulicKey, name, score, (msg) =>
        {
            _onSubmitSuccess?.Invoke();
        });
    }
}
