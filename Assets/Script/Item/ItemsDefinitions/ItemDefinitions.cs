using System;
using UnityEngine;

public class Coin : Item,IUIColor
{
    [SerializeField] Color color;

    public Color Color => color;
}

public class Bottle : Item, IUIColor
{
    public int amount;
    [SerializeField] Color color;
    public Color Color => color;
}
