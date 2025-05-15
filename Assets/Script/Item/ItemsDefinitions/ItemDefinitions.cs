using System;
using UnityEngine;

public class Coin : Item,IUIColor
{
    Color color;

    public Color Color => color;
}

public class Bottle : Item, IUIColor
{
    public int amount;
    Color color;
    public Color Color => color;
}
