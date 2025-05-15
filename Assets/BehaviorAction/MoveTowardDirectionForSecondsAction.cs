using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Move Toward Direction For Seconds", story: "[Agent] Move Toward [Direction] For [Seconds] at [Speed]", category: "Action", id: "5b0d594de6cb1e541aee777455c4c395")]
public partial class MoveTowardDirectionForSecondsAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector2> Direction;
    [SerializeReference] public BlackboardVariable<float> Seconds;
    [SerializeReference] public BlackboardVariable<UnityEngine.AI.NavMeshAgent> Agent;
    [SerializeReference] public BlackboardVariable<float> Speed;
    float timer;
    protected override Status OnStart()
    {
        timer = Time.time;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(timer + Seconds > Time.time)
        {
            Agent.Value.Move(new Vector3(Direction.Value.x, 0f, Direction.Value.y).normalized * Speed * Time.deltaTime);
            Agent.Value.transform.LookAt(Agent.Value.transform.position + new Vector3(Direction.Value.x, 0f, Direction.Value.y).normalized);
            return Status.Running;
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

