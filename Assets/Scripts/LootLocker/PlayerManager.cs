using LootLocker.Requests;
using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoginRoutine());
    }

    private IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in.");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session.");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}