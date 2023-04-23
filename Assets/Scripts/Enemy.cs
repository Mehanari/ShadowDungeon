using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private NavMeshAgent _navMesh;
    private bool _hearPlayer;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    public void Attract(Vector3 position)
    {
        _navMesh.SetDestination(position);
    }

    private void Update()
    {
        if (_hearPlayer)
        {
            _navMesh.SetDestination(_playerTransform.position);
        }
    }

    public void NoticePlayer()
    {
        _hearPlayer = true;
    }

    public void LoosePlayer()
    {
        _hearPlayer = false;
    }

}
