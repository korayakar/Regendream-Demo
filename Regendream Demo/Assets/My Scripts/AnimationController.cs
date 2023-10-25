using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetBoolean(string animationType, bool value)
    {
        animator.SetBool(animationType, value);
    }
    public void SetTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
    public void SetState(string animation)
    {
        animator.Play(animation);
    }
}
