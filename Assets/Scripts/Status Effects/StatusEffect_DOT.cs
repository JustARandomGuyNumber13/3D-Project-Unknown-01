using System.Collections;
using UnityEngine;

public class StatusEffect_DOT : StatusEffect
{
    Health target;
    public StatusEffect_DOT(SO_StatusEffectData effectData, MonoBehaviour context, Health target) : base(effectData, context)
    {
        this.target = target;
    }

    public override IEnumerator ApplyEffect()
    {
        SO_StatusData_DOT data = effectData as SO_StatusData_DOT;

        int tickCount = Mathf.FloorToInt(data.Duration / data.TickInterval);
        for (int i = 0; i < tickCount; i++)
        {
            if (data.IsPercentage)
                target.TakeDamagePercentage(data.DamagePerTick);
            else
                target.TakeDamage(data.DamagePerTick);

            yield return new WaitForSeconds(data.TickInterval);
        }

        if (context is StatusEffectHandler handler)
            handler.RemoveStatusEffect(data);
    }
}