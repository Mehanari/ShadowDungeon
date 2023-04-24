using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float _reachThreshold;
    [SerializeField] private float _playerChaseSpeed;
    [SerializeField] private float _normalSpeed;
    private Transform _playerTransform;
    private NavMeshAgent _navMesh;
    private bool _hearPlayer;
    private Vector3 _currentDestination;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetDestination(ChooseRandomRoomCenter());
        _playerTransform = Player.Instance.transform;
        _navMesh.speed = _normalSpeed;
    }

    public void Attract(Vector3 position)
    {
        if (_hearPlayer)
        {
            return;
        }
        SetDestination(position);
    }

    private void Update()
    {
        if (_hearPlayer)
        {
            SetDestination(_playerTransform.position);
        }
        else
        {
            if (ReachedRoomCenter())
            {
                SetDestination(ChooseRandomRoomCenter());
            }
        }
    }

    private bool ReachedRoomCenter()
    {
        return Mathf.Abs(transform.position.x - _currentDestination.x) < _reachThreshold &&
        Mathf.Abs(transform.position.z - _currentDestination.z) < _reachThreshold;
    }

    public void NoticePlayer()
    {
        _hearPlayer = true;
        _navMesh.speed = _playerChaseSpeed;
    }

    public void LoosePlayer()
    {
        _hearPlayer = false;
        SetDestination(ChooseRandomRoomCenter());
        _navMesh.speed = _normalSpeed;
    }

    private void SetDestination(Vector3 destination)
    {
        _currentDestination = destination;
        _navMesh.SetDestination(destination);
    }

    private Vector3 ChooseRandomRoomCenter()
    {
        var rooms = Level.Instance.RoomsPositions;
        int randI = Random.Range(0, rooms.GetLength(0));
        int randJ = Random.Range(0, rooms.GetLength(1));
        return rooms[randI, randJ];
    }

}
