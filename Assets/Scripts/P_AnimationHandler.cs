using UnityEngine;

public class P_AnimationHandler : MonoBehaviour
{
    Animator anim;

    readonly int xVelocityHash = Animator.StringToHash("xVelocity");
    readonly int zVelocityHash = Animator.StringToHash("zVelocity");
    readonly int isSprintHash = Animator.StringToHash("isSprint");
    readonly int attackTriggerHash = Animator.StringToHash("attack");
    readonly int attackIndexHash = Animator.StringToHash("attackIndex");
    readonly int isMovingHash = Animator.StringToHash("isMoving");

    private void Awake()
    {
        TryGetComponent<Animator>(out anim);
    }


    public void Animation_Walk(float xVelocity, float zVelocity, bool isMoving, bool isSprint)
    {
        anim.SetBool(isMovingHash, isMoving);
        anim.SetFloat(xVelocityHash, xVelocity);
        anim.SetFloat(zVelocityHash, zVelocity);
        anim.SetBool(isSprintHash, isSprint);
    }
    public void Animation_Attack(int attackIndex)
    { 
        anim.SetInteger(attackIndexHash, attackIndex);
        anim.SetTrigger(attackTriggerHash);
    }
}
