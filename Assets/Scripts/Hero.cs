using UnityEngine;

public class Hero : Creature
{
    [SerializeField] private FootprintSpawner _footprintSpawner;
    [SerializeField] private float _stepsPeriod;
    private float _passedDistance;
    private Vector2 _previousStepPosition;


    protected override void Update()
    {
        base.Update();
        _passedDistance += new Vector2(_velocity.x * Time.deltaTime, _velocity.z * Time.deltaTime).magnitude;

        if (_passedDistance >= _stepsPeriod)
        {
            Vector2 direction;
            if (_previousStepPosition == null)
            {
                direction = new Vector2(_velocity.x, _velocity.z).normalized;
            }
            else
            {
                var currentPosition = new Vector2(transform.position.x, transform.position.z);
                direction = currentPosition - _previousStepPosition;
                _previousStepPosition = currentPosition;
            }
            _passedDistance = 0;
            Debug.Log("Step!");
            _footprintSpawner.SpawnFootprint(direction);
        }
    }

}
