using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _roomSwitchTime;
    private NavMeshAgent _navMesh;
    private bool _hearPlayer;
    private float _elapsedTime;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _navMesh.SetDestination(ChooseRandomRoomCenter());
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
        else
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _roomSwitchTime)
            {
                _navMesh.SetDestination(ChooseRandomRoomCenter());
                _elapsedTime = 0f;
            }
        }
    }

    public void NoticePlayer()
    {
        _hearPlayer = true;
    }

    public void LoosePlayer()
    {
        _hearPlayer = false;
        _navMesh.SetDestination(ChooseRandomRoomCenter());
    }

    private Vector3 ChooseRandomRoomCenter()
    {
        var rooms = Level.Instance.RoomsPositions;
        int randI = Random.Range(0, rooms.GetLength(0));
        int randJ = Random.Range(0, rooms.GetLength(1));
        return rooms[randI, randJ];
    }

}
