using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    public void OnMovement(CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }
}
