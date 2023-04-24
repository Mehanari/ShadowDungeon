using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private int _cost;

    public void Collect()
    {
        GameSessionData.Instance.Score += _cost;
    }
}
