using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Linq;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Overlap Sphere", story: "Overlap Sphere with [Tag] and [Radius] result [Player]", category: "Action", id: "abc9363c639cfa7e6db95453c096edde")]
public partial class OverlapSphereAction : Action
{
    [SerializeReference] public BlackboardVariable<string> Tag;
    [SerializeReference] public BlackboardVariable<float> Radius;
    [SerializeReference] public BlackboardVariable<Transform> Player;

    protected override Status OnStart()
    {
        Collider[] hits = Physics.OverlapSphere(GameObject.transform.position, Radius);
        Collider player = hits.ToList().Find(a => a.transform.CompareTag(Tag));
        if (player != null)
        {
            Player.Value = player.gameObject.transform;
        }
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

