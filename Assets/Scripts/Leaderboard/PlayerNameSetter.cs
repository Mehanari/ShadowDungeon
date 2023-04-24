using TMPro;
using UnityEngine;

public class PlayerNameSetter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private string _nameTag;

    public void SetName()
    {
        PlayerPrefs.SetString(_nameTag, _inputField.text);
    }
}
