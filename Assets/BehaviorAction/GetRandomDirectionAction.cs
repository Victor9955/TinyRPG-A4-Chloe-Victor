using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetRandomDirection", story: "Get Random [Direction]", category: "Action", id: "d3ed4ab8da9bd24b956c64832d9627ca")]
public partial class GetRandomDirectionAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector2> Direction;

    protected override Status OnStart()
    {
        float random = UnityEngine.Random.Range(0f, 360f);
        Direction.Value = new Vector2(Mathf.Cos(random), Mathf.Sin(random));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

