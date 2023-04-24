using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FootprintSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _footprint;
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _feetHolder;
    [SerializeField] private float _spawnHeight;
    [SerializeField] private int _footprintsCount;
    [SerializeField] private float _angleRange;
    [SerializeField] private float _spawnPeriod;
    [SerializeField] bool _isRight;
    [SerializeField] private UnityEvent _onStepSpawned;
    private Queue<GameObject> _footprintsQueue = new Queue<GameObject>();
    private float _elapsedDistance;
    private Vector2 _previousPosition = Vector2.zero;


    private void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.z);
        float distance = (currentPosition - _previousPosition).magnitude;
        Vector2 direction = currentPosition - _previousPosition;
        _elapsedDistance += distance;
        if (_elapsedDistance >= _spawnPeriod)
        {
            _elapsedDistance = 0f;
            SpawnFootprint(direction);
        }
        _previousPosition = currentPosition;
    }


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
        _onStepSpawned?.Invoke();
    }

    private void PlaceFootprint(GameObject footprint, Vector2 movementDirection)
    {
        NormalizeFootprintScale(footprint);
        Vector3 position;
        if (_isRight)
        {
            position = _rightFoot.position;
        }
        else
        {
            position = _leftFoot.position;
            var scale = footprint.transform.localScale;
            scale.x *= -1;
            footprint.transform.localScale = scale;
        }
        position.y = _spawnHeight;
        footprint.transform.position = position;
        Vector3 rotation = new Vector3();
        rotation.y = Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg;
        _feetHolder.localEulerAngles = rotation;
        rotation.y += Random.Range(-_angleRange / 2, _angleRange / 2);
        footprint.transform.eulerAngles = rotation;
        _isRight = !_isRight;
    }

    private void NormalizeFootprintScale(GameObject footprint)
    {
        var scale = footprint.transform.localScale;
        scale.x = 1;
        footprint.transform.localScale = scale;
    }

}
