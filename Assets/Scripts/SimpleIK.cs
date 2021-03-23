using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SimpleIK : MonoBehaviour
{
    private Animator animator;

    public bool isIKActive;
    public Transform HoldObj;
    public Transform LookObj;
    [Range(0,1)]
    public float IKWeight;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            if (isIKActive)
            {
                if (LookObj != null)
                {
                    animator.SetLookAtWeight(IKWeight);
                    animator.SetLookAtPosition(LookObj.position);
                }
                if (HoldObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, IKWeight);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, IKWeight);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, HoldObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, HoldObj.rotation);
                }
            }
            else
            {
                animator.SetLookAtWeight(0);
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            }
        }
    }
}
