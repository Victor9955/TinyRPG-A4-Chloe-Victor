using UnityEngine;

public abstract class GenericFactory<BaseType> : MonoBehaviour
{
    public abstract BaseType CreateType();
}
