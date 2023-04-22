using System.Collections.Generic;
using UnityEngine;

public class FootprintSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _footprint;
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private Transform _body;
    [SerializeField] private float _spawnHeight;
    [SerializeField] private int _footprintsCount;
    [SerializeField] private float _angleRange;
    bool _isRight;
    private Queue<GameObject> _footprintsQueue = new Queue<GameObject>();
    

    private void Start()
    {
        for (int i = 0; i < _footprintsCount; i++)
        {
            var footprint = Instantiate(_footprint);
            footprint.SetActive(false);
            _footprintsQueue.Enqueue(footprint);
        }
    }

    public void SpawnFootprint(Vector2 movementDirection)
    {
        var footprint = _footprintsQueue.Dequeue();
        footprint.SetActive(true);
        _footprintsQueue.Enqueue(footprint);
        PlaceFootprint(footprint, movementDirection);
    }

    private void PlaceFootprint(GameObject footprint, Vector2 movementDirection)
    {
        Vector3 position;
        if (_isRight)
        {
            position = _rightFoot.position;
        }
        else
        {
            position = _leftFoot.position;
        }
        position.y = _spawnHeight;
        footprint.transform.position = position;
        Vector3 rotation = new Vector3();
        rotation.y = Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg;
        rotation.y += Random.Range(-_angleRange / 2, _angleRange / 2);
        footprint.transform.eulerAngles = rotation;
        _isRight = !_isRight;
    }

}
