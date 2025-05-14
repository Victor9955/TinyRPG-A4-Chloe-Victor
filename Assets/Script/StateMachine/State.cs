using UnityEngine;

public abstract class State : MonoBehaviour
{
    StateMachine _stateMachine;

    public void InitState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }
}
