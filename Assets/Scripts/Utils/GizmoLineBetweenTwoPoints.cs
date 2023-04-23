using UnityEngine;

public class GizmoLineBetweenTwoPoints : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_firstPoint.position, _secondPoint.position);
    }
}
