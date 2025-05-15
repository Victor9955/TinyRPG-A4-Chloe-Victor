using UnityEngine;

public class IdleState : State
{
    [SerializeField] float _timeBeforeSleep = 5f; //Async
    [SerializeField] InterfaceReference<IMovable> _playerDirection;
    [SerializeField] Animator _animator;

    public override void EnterState()
    {
        base.EnterState();
        _animator?.SetFloat("WalkSpeed", 0f);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_playerDirection.Value.Direction != Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.WalkState);
        }
    }
}
