using UnityEngine;
using System.Collections;

public class StatusEffect_Stun : StatusEffect
{
    Stat target;
    public StatusEffect_Stun(SO_StatusEffectData effectData, MonoBehaviour context, Stat target) : base(effectData, context)
    {
        this.target = target;
    }

    public override IEnumerator ApplyEffect()
    {
        target.IsStun = true;
        yield return new WaitForSeconds(effectData.Duration);
        target.IsStun = false;

        if (context is StatusEffectHandler handler)
            handler.RemoveStatusEffect(effectData);
    }
}
