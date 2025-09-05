using System.Collections.Generic;
using UnityEngine;

public class Skill_MeleeAttackBehavior : Skill
{
    [Header("Skill exclusive data")]
    DamageCollider[] dmgColliders;
    public P_AnimationHandler anim;
    SO_AttackData attackData;

    HashSet<Collider> attackTracker = new();

    protected override void OnConvertSkillData()
    {
        attackData = data as SO_AttackData;

        dmgColliders = handler.GetDamageColliders(attackData.DamageCollider);

        foreach (var dmg in dmgColliders)
            dmg.OnTriggerEnterEvent.AddListener(OnDamageColliderTriggerEnter);
    }

    protected override void OnSkillDelay()
    {
        base.OnSkillDelay();
        attackTracker.Clear();
        stat.IsCanMove = false;
        anim.Animation_StartSkill(attackData.animationClip);
        anim.Animation_EndSkill();
    }
    protected override void OnSkillActive()
    {
        base.OnSkillActive();
        Helper_ToggleCollider(true);
    }
    protected override void OnSkillEnd()
    {
        base.OnSkillEnd();
        stat.IsCanMove = true;
        Helper_ToggleCollider(false);
    }

    private void Helper_ToggleCollider(bool value)
    {
        if (dmgColliders.Length == 0) return;
        foreach (var dmg in dmgColliders)
            dmg.enabled = value;
    }
    private void OnDamageColliderTriggerEnter(Collider other)
    {
        Health target; other.TryGetComponent<Health>(out target);

        if (!attackTracker.Add(other)) return;

        if (attackData.status.Length > 0)
        {
            StatusEffectHandler effect; other.TryGetComponent<StatusEffectHandler>(out effect);
            
            if(effect != null)
                foreach(SO_StatusEffectData e in attackData.status)
                    effect.ApplyStatusEffect(e);
        }

        if (target != null)
            target.TakeDamage(attackData.DamageAmount);
    }
}
