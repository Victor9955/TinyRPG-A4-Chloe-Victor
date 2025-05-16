using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Raycast Forward", story: "Raycast Detect With [Size] From [Agent]", category: "Conditions", id: "1d984c941332b0dcf8afdee206451eb1")]
public partial class RaycastForwardCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> Size;
    [SerializeReference] public BlackboardVariable<Transform> Agent;

    public override bool IsTrue()
    {
        if(Physics.Raycast(Agent.Value.position,Agent.Value.forward,out RaycastHit hitInfo, Size))
        {
            if(hitInfo.transform != Agent.Value)
            {
                return false;
            }
        }
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
