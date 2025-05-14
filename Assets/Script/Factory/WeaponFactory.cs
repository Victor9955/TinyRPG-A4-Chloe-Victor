using UnityEngine;

[CreateAssetMenu(fileName = "WeaponFactory", menuName = "Scriptable Objects/WeaponFactory")]
public class WeaponFactory : ItemFactory
{
    public override IItem CreateType()
    {
        return null;
    }
}
