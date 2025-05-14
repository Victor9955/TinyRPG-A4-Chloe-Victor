using UnityEngine;

[CreateAssetMenu(fileName = "GenericFactory", menuName = "Scriptable Objects/GenericFactory")]
public abstract class GenericFactory<BaseType> : ScriptableObject
{
    public abstract BaseType CreateType();
}
