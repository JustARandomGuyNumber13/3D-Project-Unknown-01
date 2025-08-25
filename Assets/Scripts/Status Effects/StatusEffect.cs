using System.Collections;
using UnityEngine;

public abstract class StatusEffect
{
    protected MonoBehaviour context;
    protected SO_StatusEffectData data;

    public StatusEffect(SO_StatusEffectData data, MonoBehaviour context)
    {
        this.data = data;
        this.context = context;
    }

    public abstract IEnumerator ApplyEffect();
}

public class StatusEffect_Burn : StatusEffect
{
    Health target;
    public StatusEffect_Burn(SO_StatusEffectData data, MonoBehaviour context, Health target) : base(data, context)
    {
        this.target = target;
    }

    public override IEnumerator ApplyEffect()
    {
        SO_StatusData_Burn burnData = data as SO_StatusData_Burn;

        int tickCount = Mathf.FloorToInt(burnData.Duration / burnData.TickInterval);

        for (int i = 0; i < tickCount; i++)
        {
            yield return new WaitForSeconds(burnData.TickInterval);

            if (burnData.IsPercentage)
                target.TakeDamagePercentage(burnData.DamagePerTick);
            else
                target.TakeDamage(burnData.DamagePerTick);
        }

        if(context is StatusEffectHandler handler)
            handler.RemoveStatusEffect(data);
    }
}