using System;
using Unity.Behavior;
using UnityEngine;
using Modifier = Unity.Behavior.Modifier;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RepeatForSeconds", story: "Repeat For [X] Seconds", category: "Flow/Repeat", id: "b68809f3fc5c1782d61be868680fa6e1")]
public partial class RepeatForSecondsModifier : Modifier
{
    [SerializeReference] public BlackboardVariable<float> X;
    float timer;
    protected override Status OnStart()
    {
        timer = Time.time;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (timer + X.Value < Time.time)
        {
            return Status.Running;
        }
        else
        {
            return Status.Success;
        }
    }

    protected override void OnEnd()
    {
    }
}

