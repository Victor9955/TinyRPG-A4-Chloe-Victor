using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] float _timeBeforeSleep = 2f;
    [SerializeField] InterfaceReference<IMoveInput> _playerDirection;
    [SerializeField] InterfaceReference<IAttackInput> _playerAttack;
    CancellationTokenSource _cancellationToken;

    [Header("Animator")]
    string _animatorWalkSpeedName = "WalkSpeed";
    [SerializeField] Animator _animator;
    public override void EnterState()
    {
        base.EnterState();
        _cancellationToken = new CancellationTokenSource();
        _animator?.SetFloat(_animatorWalkSpeedName, 0f);
        StartTimerSleepState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_playerDirection.Value.Direction != Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.WalkState);
        }

        if (_playerAttack.Value.IsAttacking)
        {
            _stateMachine.ChangeState(_stateMachine.AttackState);
        }
    }

    private async UniTaskVoid StartTimerSleepState()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_timeBeforeSleep), false, PlayerLoopTiming.Update, _cancellationToken.Token);
        _stateMachine.ChangeState(_stateMachine.SleepingState);
    }

    public override void ExitState()
    {
        base.ExitState();
        _cancellationToken.Cancel();
    }
}
