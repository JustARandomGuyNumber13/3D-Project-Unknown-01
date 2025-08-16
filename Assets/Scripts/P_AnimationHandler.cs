using UnityEngine;

public class P_AnimationHandler : MonoBehaviour
{
    Animator anim;

    readonly int xInputHash = Animator.StringToHash("xInput");
    readonly int yInputHash = Animator.StringToHash("yInput");
    readonly int isSprintHash = Animator.StringToHash("isSprint");


    private void Awake()
    {
        TryGetComponent<Animator>(out anim);
    }


    public void Animation_Walk(float xInput, float yInput, bool isSprint)
    { 
        anim.SetFloat(xInputHash, xInput);
        anim.SetFloat(yInputHash, yInput);
        anim.SetBool(isSprintHash, isSprint);
    }
}
