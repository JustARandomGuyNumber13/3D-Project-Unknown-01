using System.Collections;
using UnityEngine;

public class StatusEffect_MaxHealth : StatusEffect
{
    Stat target;
    public StatusEffect_MaxHealth(SO_StatusEffectData effectData, MonoBehaviour context, Stat target) : base(effectData, context)
    {
        this.target = target;
    }

    public override IEnumerator ApplyEffect()
    {
        SO_StatusData_MaxHealth data = effectData as SO_StatusData_MaxHealth;

        float value = data.IsPercentage ? (target.CurrentMaxHealth * data.AdditionalValue / 100) : data.AdditionalValue;
        target.CurrentMaxHealth += value;

        if(data.AdditionalValue > 0)
            target.CurrentHealth += value;
        else
            if (target.CurrentHealth > target.CurrentMaxHealth)
                target.CurrentHealth = target.CurrentMaxHealth;

        yield return new WaitForSeconds(data.Duration);
        target.CurrentMaxHealth -= value;

        if(target.CurrentHealth > target.CurrentMaxHealth)
            target.CurrentHealth = target.CurrentMaxHealth;

        (context as StatusEffectHandler).RemoveStatusEffect(data);
    }
}
