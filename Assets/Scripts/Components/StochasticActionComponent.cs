using UnityEngine;
using UnityEngine.Events;

public class StochasticActionComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;
    [SerializeField] [Range(0, 100)] private float _probabilityValue = 50f;
    [SerializeField] private bool _invokeOnAwake;

    private void Awake()
    {
        if (_invokeOnAwake)
        {
            InvokeStochasticAction();
        }
    }

    public void InvokeStochasticAction()
    {
        bool invoke = Random.Range(0, 100) <= _probabilityValue;
        if (invoke)
        {
            _action.Invoke();
        }
    }
}
