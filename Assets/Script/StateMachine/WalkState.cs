using UnityEngine;
using UnityEngine.AI;

public class WalkState : State
{
    [SerializeField] float _speed = 5f;
    [SerializeField] InterfaceReference<IMoveInput> _playerDirection;
    [SerializeField] InterfaceReference<IAttackInput> _playerAttack;
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
        Vector3 inputDirection = new Vector3(_playerDirection.Value.Direction.x, 0 , _playerDirection.Value.Direction.y);
        _navMeshAgent.Move(inputDirection * _speed * Time.deltaTime);
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, inputDirection, 360, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);

        if (_playerDirection.Value.Direction == Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }

        if (_playerAttack.Value.IsAttacking)
        {
            _stateMachine.ChangeState(_stateMachine.AttackState);
        }
    }
}
