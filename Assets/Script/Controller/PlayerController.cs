using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour,IMovable
{
    Controls controls;

    public Vector2 Direction { get => controls.Game.Move.ReadValue<Vector2>().normalized; }

    private void Start()
    {
        controls = new Controls();
        controls.Enable();
    }
}
