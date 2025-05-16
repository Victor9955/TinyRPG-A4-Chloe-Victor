using System.Threading;
using UnityEngine;

public class SleepingState : State
{
    [SerializeField] InterfaceReference<IMoveInput> _playerDirection;
    [SerializeField] InterfaceReference<IAttackInput> _playerAttack;

    [Header("Animator")]
    [SerializeField] AnimationEndEvent _animEndEvent;
    [SerializeField] Animator _animator;
    [SerializeField] string _animatorLieName = "IsSleeping";
    [SerializeField] string _animationEndEventName;
    bool _isAnimationSleepingFinished;

    public override void EnterState()
    {
        base.EnterState();
        _animEndEvent.OnAnimationEnd += OnAnimationEnd;
        _isAnimationSleepingFinished = false;
        _animator?.SetBool(_animatorLieName, true);
    }

    private void OnAnimationEnd(string name)
    {
        if (_animationEndEventName == name)
        {
            _isAnimationSleepingFinished = true;
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_playerDirection.Value.Direction != Vector2.zero || _playerAttack.Value.IsAttacking)
        {
            _animator?.SetBool(_animatorLieName, false);
        }
        if (_isAnimationSleepingFinished)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _animEndEvent.OnAnimationEnd -= OnAnimationEnd;
    }
}
