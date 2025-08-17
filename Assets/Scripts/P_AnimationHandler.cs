using UnityEngine;

public class P_AnimationHandler : MonoBehaviour
{
    Animator anim;

    readonly int xVelocityHash = Animator.StringToHash("xVelocity");
    readonly int zVelocityHash = Animator.StringToHash("zVelocity");
    readonly int isSprintHash = Animator.StringToHash("isSprint");


    private void Awake()
    {
        TryGetComponent<Animator>(out anim);
    }


    public void Animation_Walk(float xVelocity, float zVelocity, bool isSprint)
    { 
        anim.SetFloat(xVelocityHash, xVelocity);
        anim.SetFloat(zVelocityHash, zVelocity);
        anim.SetBool(isSprintHash, isSprint);
    }
}
