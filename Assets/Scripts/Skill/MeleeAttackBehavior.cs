using UnityEngine;

public class MeleeAttackBehavior : Skill
{
    [Header("Skill exclusive data")]
    [SerializeField] Collider DamageCollider;
    [SerializeField] AnimationClip clip;
    public P_AnimationHandler anim;
    SO_AttackData attackData;

    private void Start()
    {
        attackData = data as SO_AttackData;
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
        Health target; other.TryGetComponent<Health>(out target);

        if (target != null)
            target.TakeDamage(attackData.DamageAmount);

        if (attackData.status.Length > 0)
        {
            StatusEffectHandler effect; other.TryGetComponent<StatusEffectHandler>(out effect);
            
            if(effect != null)
                foreach(SO_StatusEffectData e in attackData.status)
                    effect.ApplyStatusEffect(e);
        }
    }
}
