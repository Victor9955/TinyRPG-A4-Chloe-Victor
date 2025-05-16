using System;
using Unity.Behavior;
using UnityEngine;
using Composite = Unity.Behavior.Composite;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RepeatForSeconds", story: "Repeat For [Seconds]", category: "Flow", id: "53996741399248e9019a8d66e80b7e99")]
public partial class RepeatForSecondsSequence : Composite
{
    [SerializeReference] public BlackboardVariable<float> Seconds;
    float timer;
    protected override Status OnStart()
    {
        timer = Time.time;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(timer + Seconds.Value > Time.time)
        {
            return Status.Waiting;
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

