using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Move Toward", story: "[Agent] Move Toward [Direction] At [Speed]", category: "Action", id: "62edcb0d6178557b4768f6522319adfc")]
public partial class MoveTowardAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector2> Direction;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<UnityEngine.AI.NavMeshAgent> Agent;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Agent.Value.Move(new Vector3(Direction.Value.x, 0f, Direction.Value.y).normalized * Speed * Time.deltaTime);
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

