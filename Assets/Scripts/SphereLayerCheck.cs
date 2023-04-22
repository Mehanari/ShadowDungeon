using UnityEngine;

public class SphereLayerCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _sphereRadius;

    public bool TouchesLayer()
    {
        return Physics.CheckSphere(transform.position, _sphereRadius, _layerMask);
    }

    private void OnDrawGizmosSelected() 
    {
        if (Physics.CheckSphere(transform.position, _sphereRadius, _layerMask))
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawSphere(transform.position, _sphereRadius);
    }
}
