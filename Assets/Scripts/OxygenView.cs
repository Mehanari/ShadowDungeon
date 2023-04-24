using TMPro;
using UnityEngine;

public class OxygenView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private string _text;

    private void Update()
    {
        int oxygen = (int)Player.Instance.Oxygen;
        _textMesh.text = _text + oxygen;
    }
}
