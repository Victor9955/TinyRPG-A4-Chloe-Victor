using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }


    [SerializeField] State _walkState;
    [SerializeField] State _attackState;
    public State WalkState => _walkState;
    public State AttackState => _attackState;


    State[] _states => new State[]
    {
        WalkState
    };

    private void Awake()
    {
        foreach (State state in _states)
        {
            state.InitState(this);
        }
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
