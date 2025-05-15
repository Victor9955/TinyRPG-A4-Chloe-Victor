using UnityEngine;

public class AttackState : State
{
    [SerializeField] Animator _animator;
    [SerializeField] AnimationEndEvent _attackAnim;
    bool _hasFinishAttacking;

    private void Awake()
    {
        _attackAnim.OnAnimationEnd += OnAttackAnimationEnd;
    }

    private void OnAttackAnimationEnd()
    {
        _hasFinishAttacking = true;
    }

    public override void EnterState()
    {
        base.EnterState();
        _hasFinishAttacking = false;
        _animator?.SetTrigger("Attack");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_animator != null && _hasFinishAttacking)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }
}
