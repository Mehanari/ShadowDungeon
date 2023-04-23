using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerComponent : MonoBehaviour
{
    [SerializeField] private List<string> _tags;
    [SerializeField] private UnityEvent _action;

    private void OnTriggerEnter(Collider other)
    {
        if (ColliderHasRequiredTag(other))
        {
            _action.Invoke();
        }
    }

    private bool ColliderHasRequiredTag(Collider other)
    {
        foreach (var tag in _tags)
        {
            if (other.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
