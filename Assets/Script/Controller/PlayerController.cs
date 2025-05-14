using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Controls controls;

    [SerializeField] private InterfaceReference<IMovable> _movable;

    private void Start()
    {
        controls = new Controls();
        controls.Enable();
        controls.Game.Move.performed += DoMove;
    }

    private void DoMove(InputAction.CallbackContext context)
    {
        _movable?.Value.Move(context.ReadValue<Vector2>().normalized);
    }
}
