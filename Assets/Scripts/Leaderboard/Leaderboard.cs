using TMPro;
using UnityEngine;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string _highScoreTag;
    [SerializeField] private TextMeshProUGUI _playerNames;
    [SerializeField] private TextMeshProUGUI _playerScores;
    [SerializeField] private int _entriesCount;
    [SerializeField] private bool _updateOnStart;
    private string _publicKey = "daf3b60a27e200465138ebda2a1c6acc49a985151969a9b1d038b9e89b12c4ca";

    private void Start()
    {
        if (_updateOnStart)
        {
            UpdateLeaderboard();
        }
    }

    public void UpdateLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(_publicKey, (msg) =>
        {
            string names = "Names:\n";
            string scores = "Scores:\n";
            int count = 0;
            if (msg.Length < _entriesCount)
            {
                count = msg.Length;
            }
            else
            {
                count = _entriesCount;
            }
            for (int i = 0; i < count; i++)
            {
                names += (i+1) + ". " + msg[i].Username + "\n";
                scores += msg[i].Score + "\n";
            }
            _playerNames.text = names;
            _playerScores.text = scores;
        });
    }
}
