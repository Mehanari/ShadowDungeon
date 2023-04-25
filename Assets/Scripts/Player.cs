using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Player : Creature
{
    public static Player Instance;
    [SerializeField] private UnityEvent _onLose;
    [SerializeField] private string _highScoreTag;
    [SerializeField] private SphereCollider _soundZoneCollider;
    [SerializeField] private float _normalSoundZoneRadius;
    [SerializeField] private float _heldBreathSoundZoneRadius;
    [SerializeField] private float _soundZoneResizeSpeed = 0.4f;
    [SerializeField] private float _maxOxygen;
    [SerializeField] private float _oxygenChangeSpeed;
    [SerializeField] private float _heldBreathSpeed;
    public float Oxygen => _currentOxygen;
    private bool _breathHeld = false;
    private float _currentOxygen;
    private float _maxSpeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        _currentOxygen = _maxOxygen;
        _maxSpeed = _speed;
    }

    public void Lose()
    {
        _onLose?.Invoke();
        Debug.Log("Lose");
        int highScore = PlayerPrefs.GetInt(_highScoreTag, 0);
        int currentScore = GameSessionData.Instance.Score;
        if (highScore < currentScore)
        {
            PlayerPrefs.SetInt(_highScoreTag, currentScore);
        }
    }

    protected override void Update()
    {
        base.Update();
        if (_breathHeld)
        {
            if (_currentOxygen <= 0)
            {
                ReleaseBreath();
            }
            else
            {
                _currentOxygen -= _oxygenChangeSpeed * Time.deltaTime;
                if (_soundZoneCollider.radius >= _heldBreathSoundZoneRadius)
                {
                    _soundZoneCollider.radius -= _soundZoneResizeSpeed * Time.deltaTime;
                }
            }
        }
        else
        {
            if (_currentOxygen <= _maxOxygen)
            {
                _currentOxygen += _oxygenChangeSpeed * Time.deltaTime;
            }
            if (_soundZoneCollider.radius <= _normalSoundZoneRadius)
            {
                _soundZoneCollider.radius += _soundZoneResizeSpeed * Time.deltaTime;
            }
        }
    }

    public void HoldBreath() 
    {
        _breathHeld = true;
        _speed = _heldBreathSpeed;
    }

    public void ReleaseBreath()
    {
        _breathHeld = false;
        _speed = _maxSpeed;
    }
}
