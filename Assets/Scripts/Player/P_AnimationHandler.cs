using UnityEngine;

public class P_AnimationHandler : MonoBehaviour
{
    [SerializeField] AnimatorOverrideController animatorOverrideController;
    Animator anim;

    readonly int xVelocityHash = Animator.StringToHash("xVelocity");
    readonly int zVelocityHash = Animator.StringToHash("zVelocity");
    readonly int isMovingHash = Animator.StringToHash("isMoving");
    readonly int isSprintHash = Animator.StringToHash("isSprint");
    readonly int startSkillHash = Animator.StringToHash("skillStart");
    readonly int endSkillHash = Animator.StringToHash("skillEnd");

    int armLayer;
    int legLayer;
    string performSkillState;

    private void Awake()
    {
        TryGetComponent<Animator>(out anim);
        armLayer = anim.GetLayerIndex("Arm Layer");
        legLayer = anim.GetLayerIndex("Leg Layer");
        performSkillState = "Punch";
    }


    public void Animation_Walk(float xVelocity, float zVelocity, bool isMoving, bool isSprint)
    {
        anim.SetBool(isMovingHash, isMoving);
        anim.SetFloat(xVelocityHash, xVelocity);
        anim.SetFloat(zVelocityHash, zVelocity);
        anim.SetBool(isSprintHash, isSprint);
    }
    public void Animation_StartSkill(AnimationClip clip)
    {
        animatorOverrideController[performSkillState] = clip;
        anim.SetTrigger(startSkillHash);
    }
    public void Animation_EndSkill()
    {
        anim.SetTrigger(endSkillHash);
    }
}
