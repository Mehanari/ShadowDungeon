using LootLocker.Requests;
using System.Collections;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string _highScoreTag;
    [SerializeField] private TextMeshProUGUI _playerNames;
    [SerializeField] private TextMeshProUGUI _playerScores;
    private string _leaderBoardKey = "TestGlobalHighscore";

    public void SubmitPlayerScore()
    {
        int highScore = PlayerPrefs.GetInt(_highScoreTag);
        StartCoroutine(SubmitScoreRoutine(highScore));
    }

    private IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, _leaderBoardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully uploaded score.");
                done = true;
            }
            else
            {
                Debug.Log("Could not upload score.");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public void ShowTopHighScores()
    {
        StartCoroutine(FetchTopHighScoresRoutine());
    }

    private IEnumerator FetchTopHighScoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(_leaderBoardKey, 10, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                _playerNames.text = tempPlayerNames;
                _playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
