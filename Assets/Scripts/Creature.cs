using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] protected CharacterController _characterController;
    [SerializeField] protected float _speed;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private SphereLayerCheck _groundCheck;
    protected Vector2 _direction;

    protected Vector3 _velocity;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    protected virtual void Update()
    {
        _velocity.x = _direction.x * _speed;
        _velocity.z = _direction.y * _speed;
        _characterController.Move(new Vector3(_velocity.x * Time.deltaTime, 0, _velocity.z * Time.deltaTime));
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity* Time.deltaTime);
        if (_groundCheck.TouchesLayer())
        {
            _velocity.y = 0;
        }
    }
}
