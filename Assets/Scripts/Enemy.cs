using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private NavMeshAgent _navMesh;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMesh.SetDestination(_playerTransform.position);
    }
}
