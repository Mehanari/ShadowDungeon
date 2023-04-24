using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private Player _hero;

    public void OnMovement(CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }

    public void OnHoldBreath(CallbackContext context)
    {
        if (context.started)
        {
            _hero.HoldBreath();
        }
        else if (context.canceled)
        {
            _hero.ReleaseBreath();
        }
    }
}
