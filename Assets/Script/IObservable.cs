using System;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable<T>
{
    public event Action<T> OnValueChanged;
}
