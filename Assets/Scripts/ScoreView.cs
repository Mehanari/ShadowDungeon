using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    private void Start()
    {
        GameSessionData.Instance.OnScoreChanged.AddListener(UpdateScore);
    }

    public void UpdateScore()
    {
        _textMesh.text = GameSessionData.Instance.Score.ToString();
    }

    private void OnDestroy()
    {
        GameSessionData.Instance.OnScoreChanged.RemoveListener(UpdateScore);
    }
}
