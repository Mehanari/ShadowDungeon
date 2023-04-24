using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [Header("Component prefabs")]
    [SerializeField] private GameObject _entranceOpened;
    [SerializeField] private GameObject _entranceClosed;
    [Header("Entrances positions")]
    [SerializeField] private Entrance _north;
    [SerializeField] private Entrance _south;
    [SerializeField] private Entrance _east;
    [SerializeField] private Entrance _west;
    public Entrance North => _north;
    public Entrance South => _south;
    public Entrance East => _east;
    public Entrance West => _west;

    public void RotateContent(int degrees)
    {
        var rotation = _content.transform.eulerAngles;
        rotation.y = degrees;
        _content.transform.eulerAngles = rotation;
    }

    public bool HasThreeExits()
    {
        Entrance[] entrances = new Entrance[4] { _north, _south, _east, _west };
        int openedEntrancesCount = 0;
        foreach (var entrance in entrances)
        {
            if (!entrance.IsClosed)
            {
                openedEntrancesCount++;
            }
        }
        return openedEntrancesCount == 3;
    }
    
    public void SetOpenedEntrance(EntrancesPositions position)
    {
        var entrance = GetEntranceByPosition(position);
        if (entrance.IsSet)
        {
            Destroy(entrance.Object);
        }
        entrance.IsClosed = false;
        var instance = SpawnObjectOnTransform(_entranceOpened, entrance.Transform);
        entrance.Object = instance;
    }

    public void SetClosedEntrance(EntrancesPositions position)
    {
        var entrance = GetEntranceByPosition(position);
        if (entrance.IsSet)
        {
            Destroy(entrance.Object);
        }
        entrance.IsClosed = true;
        var instance = SpawnObjectOnTransform(_entranceClosed, entrance.Transform);
        entrance.Object = instance;
    }

    private Entrance GetEntranceByPosition(EntrancesPositions position)
    {
        Entrance chosenEntrance;
        switch (position)
        {
            case EntrancesPositions.North:
                chosenEntrance = _north;
                break;
            case EntrancesPositions.South:
                chosenEntrance = _south;
                break;
            case EntrancesPositions.East:
                chosenEntrance = _east;
                break;
            case EntrancesPositions.West:
                chosenEntrance = _west;
                break;
            default:
                chosenEntrance = _north;
                break;
        }
        return chosenEntrance;
    }
    
    private GameObject SpawnObjectOnTransform(GameObject obj, Transform transform)
    {
        var instance = Instantiate(obj, transform);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localEulerAngles = Vector3.zero;
        return instance;
    }

    [System.Serializable]
    public class Entrance
    {
        public Transform Transform;
        public GameObject Object;
        public bool IsClosed;
        public bool IsSet;
    }
}

public enum EntrancesPositions
{
    North,
    South,
    East,
    West
}