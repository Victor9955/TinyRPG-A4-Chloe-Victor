using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }


    [SerializeField] State _idleState;
    [SerializeField] State _walkState;
    [SerializeField] State _attackState;
    [SerializeField] State _sleepingState;
    public State IdleState => _idleState;
    public State WalkState => _walkState;
    public State AttackState => _attackState;
    public State SleepingState => _sleepingState;
    State[] _states => new State[]
    {
        IdleState,
        WalkState,
        AttackState,
        SleepingState
    };

    private void Awake()
    {
        foreach (State state in _states)
        {
            state.InitState(this);
        }
    }

    private void Start()
    {
        ChangeState(IdleState);
    }

    public void ChangeState(State state)
    {
        CurrentState?.ExitState();

        CurrentState = state;

        CurrentState?.EnterState();
    }
    
    private void Update()
    {
        CurrentState?.UpdateState();    
    }
}
