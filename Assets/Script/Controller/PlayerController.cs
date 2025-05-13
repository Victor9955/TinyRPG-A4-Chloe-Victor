using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputRef _inputRef;

    [SerializeField] private InterfaceReference<IMovable> _movable;

    private void Start()
    {
        _inputRef.actions.Move.performed += DoMove;
    }

    private void DoMove(InputAction.CallbackContext context)
    {
        _movable?.Value.Move(context.ReadValue<Vector2>().normalized);
        Debug.Log(context.ReadValue<Vector2>().normalized);
    }
}
