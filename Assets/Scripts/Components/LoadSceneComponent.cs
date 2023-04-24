using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneComponent : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void GoToScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
