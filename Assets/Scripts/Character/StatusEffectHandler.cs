using System.Collections.Generic;
using UnityEngine;
using static SO_StatusEffectData.EffectType;


public class StatusEffectHandler : MonoBehaviour
{
    Stat stat;
    Health health;
    Dictionary<SO_StatusEffectData.EffectType, StatusEffect> activeStatusEffects = new();

    private void Awake()
    {
        TryGetComponent<Stat>(out stat);
        TryGetComponent<Health>(out health);    
    }

    public void ApplyStatusEffect(SO_StatusEffectData data)
    {
        int applyChance = Random.Range(0, 100);
        print("Status " + data.Effect + " apply chance: " + data.ApplyChance + ", result: " + applyChance);
        if (applyChance > data.ApplyChance)
        {
            print("Apply status " + data.Effect + ", fail !");
            print("---");
            return;
        }
        StatusEffect effect = null;

        if(activeStatusEffects.ContainsKey(data.Effect))
            print("Apply status " + data.Effect + ", fail ! Effect already exist");

        switch (data.Effect)
        {
            case None:
                break;
            case Burn:
                effect = new StatusEffect_Burn(data, this, health);
                break;
        }

        if (effect != null && !activeStatusEffects.ContainsKey(data.Effect))
        {
            print("Apply status " + data.Effect + ", succesfully!");
            activeStatusEffects.Add(data.Effect, effect);
            StartCoroutine(effect.ApplyEffect());
        }
        print("---");
    }
    public void RemoveStatusEffect(SO_StatusEffectData data)
    {
        print("Status effect " + data.Effect + " end");
        activeStatusEffects.Remove(data.Effect);
    }
}
