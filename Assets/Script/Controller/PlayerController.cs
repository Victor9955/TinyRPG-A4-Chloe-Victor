using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour, IMoveInput, IAttackInput
{
    [SerializeField] private float _inputThreshold = 0.01f;
    Controls controls;

    public Vector2 Direction { get => controls.Game.Move.ReadValue<Vector2>().normalized; }

    public bool IsAttacking { get => controls.Game.Attack.ReadValue<float>() > _inputThreshold; }

    private void Start()
    {
        controls = new Controls();
        controls.Enable();
    }
}
