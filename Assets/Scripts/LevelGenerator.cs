using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Room _roomPrefab;
    [SerializeField] private float _roomLength;
    [SerializeField] private int _gameFieldSize;
    private Vector3[,] _roomsPositions;
    private Room[,] _rooms;

    private void Start()
    {
        GeneratePositions();
        CreateRooms();
        CloseSides();
        CreateDoors();
        CreateVerticalWalls();
        CreateHorizontalWalls();
    }

    private void GeneratePositions()
    {
        _roomsPositions = new Vector3[_gameFieldSize,_gameFieldSize];
        for (int i = 0; i < _gameFieldSize; i++)
        {
            for (int j = 0; j < _gameFieldSize; j++)
            {
                _roomsPositions[i,j].z = _roomLength * i;
                _roomsPositions[i,j].x = _roomLength * j;
            }
        }
    }

    private void CreateRooms()
    {
        _rooms = new Room[_gameFieldSize,_gameFieldSize];
        for (int i = 0; i < _gameFieldSize; i++)
        {
            for (int j = 0; j < _gameFieldSize; j++)
            {
                _rooms[i,j] = Instantiate(_roomPrefab.gameObject, _roomsPositions[i,j], Quaternion.identity).GetComponent<Room>();
            }
        }
    }

    private void CloseSides()
    {
        for (int i = 0; i < _gameFieldSize; i++)
        {
            _rooms[0, i].SetClosedEntrance(EntrancesPositions.South);
            _rooms[_gameFieldSize - 1, i].SetClosedEntrance(EntrancesPositions.North);
            _rooms[i, 0].SetClosedEntrance(EntrancesPositions.West);
            _rooms[i, _gameFieldSize - 1].SetClosedEntrance(EntrancesPositions.East);
        }
    }

    private void CreateDoors()
    {
        for (int i = 0; i < _gameFieldSize; i++)
        {
            for (int j = 0; j < _gameFieldSize; j++)
            {
                var room = _rooms[i, j];
                if (!room.North.IsClosed)
                {
                    room.SetOpenedEntrance(EntrancesPositions.North);
                }
                if (!room.South.IsClosed)
                {
                    room.SetOpenedEntrance(EntrancesPositions.South);
                }
                if (!room.East.IsClosed)
                {
                    room.SetOpenedEntrance(EntrancesPositions.East);
                }
                if (!room.West.IsClosed)
                {
                    room.SetOpenedEntrance(EntrancesPositions.West);
                }
            }
        }
    }

    private void CreateVerticalWalls()
    {
        int previousWallIndex = -1;
        for (int i = 0; i < _gameFieldSize; i++)
        {
            int wallIndex = Random.Range(0, _gameFieldSize - 2);
            if (wallIndex == previousWallIndex)
            {
                if (wallIndex == _gameFieldSize-2)
                {
                    wallIndex--;
                }
                else
                {
                    wallIndex++;
                }
            }
            previousWallIndex = wallIndex;
            Room firstRoom = _rooms[i, wallIndex];
            Room secondRoom = _rooms[i, wallIndex+1];
            firstRoom.SetClosedEntrance(EntrancesPositions.East);
            secondRoom.SetClosedEntrance(EntrancesPositions.West);
        }
    }

    private void CreateHorizontalWalls()
    {
        for (int i = 0; i < _gameFieldSize; i++)
        {
            for (int j = 0; j < _gameFieldSize-1; j++)
            {
                var firstRoom = _rooms[j, i];
                var secondRoom = _rooms[j+1, i];
                if (firstRoom.HasThreeExits() && secondRoom.HasThreeExits())
                {
                    firstRoom.SetClosedEntrance(EntrancesPositions.North);
                    secondRoom.SetClosedEntrance(EntrancesPositions.South);
                    continue;
                }
            }

        }
    }

}
