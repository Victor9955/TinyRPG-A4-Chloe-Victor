using UnityEngine;

public class AttackState : State
{
    [SerializeField] Animator _animator;
    [SerializeField] AnimationEndEvent _animEndEvent;
    [SerializeField] string _animationAttackName = "Attack";
    [SerializeField] string _attackEndEventName = "Attack";
    bool _hasFinishAttacking;

    private void OnAttackAnimationEnd(string animationName)
    {
        if (_attackEndEventName == animationName)
        {
            _hasFinishAttacking = true;
        }
    }

    public override void EnterState()
    {
        base.EnterState();
        _animEndEvent.OnAnimationEnd += OnAttackAnimationEnd;
        _hasFinishAttacking = false;
        _animator?.SetTrigger(_animationAttackName);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_hasFinishAttacking)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _animEndEvent.OnAnimationEnd -= OnAttackAnimationEnd;
    }
}
