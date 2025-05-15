using UnityEngine;
using UnityEngine.AI;

public class WalkState : State
{
    [SerializeField] float _speed = 5f;
    [SerializeField] InterfaceReference<IMovable> _playerDirection;
    [SerializeField] Animator _animator;
    [SerializeField] NavMeshAgent _navMeshAgent;

    public override void EnterState()
    {
        base.EnterState();
        _animator?.SetFloat("WalkSpeed", _speed);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 direction = new Vector3(_playerDirection.Value.Direction.x, 0 , _playerDirection.Value.Direction.y);
        _navMeshAgent.Move(direction * _speed * Time.deltaTime);

        if (_playerDirection.Value.Direction == Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }
}
