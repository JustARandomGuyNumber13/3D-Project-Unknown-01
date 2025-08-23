using UnityEngine;

public class MeleeAttackBehavior : Skill
{
    [Header("Skill exclusive data")]
    [SerializeField] P_AnimationHandler anim;
    [SerializeField] AnimationClip clip;
    public Collider DamageCollider;

    protected SO_Skill_AttackData attackData;

    protected override void Awake()
    {
        base.Awake();
        attackData = (SO_Skill_AttackData)data;
    }

    protected override void OnSkillDelay()
    {
        base.OnSkillDelay();
        anim.Animation_StartSkill(clip);
        anim.Animation_EndSkill();
    }
    protected override void OnSkillActive()
    {
        base.OnSkillActive();
        DamageCollider.enabled = true;
    }
    protected override void OnSkillEnd()
    {
        base.OnSkillEnd();
        DamageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health target;
        other.TryGetComponent<Health>(out target);

        if (target != null)
        {
            target.TakeDamage(attackData.DamageAmount);
        }
    }
}
