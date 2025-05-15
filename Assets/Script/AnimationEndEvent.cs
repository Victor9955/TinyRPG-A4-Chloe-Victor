using System;
using UnityEngine;

public class AnimationEndEvent : MonoBehaviour
{
    public event Action OnAnimationEnd;

    public void EndEvent(string animationString)
    {
        OnAnimationEnd?.Invoke();
    }   
}
