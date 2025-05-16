using System;
using UnityEngine;

public class AnimationEndEvent : MonoBehaviour
{
    public event Action<string> OnAnimationEnd;

    public void EndEvent(string animationString)
    {
        OnAnimationEnd?.Invoke(animationString);
    }   
}
