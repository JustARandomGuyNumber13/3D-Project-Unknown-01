using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static SO_StatusEffectData.EffectType;


public class StatusEffectHandler : MonoBehaviour
{
    Character character;
    Dictionary<SO_StatusEffectData.EffectType, StatusEffect> activeStatusEffects = new();

    public UnityEvent<SO_StatusEffectData> ApplyStatusEffectEvent;
    public UnityEvent<SO_StatusEffectData> RemoveStatusEffectEvent;

    private void Awake()
    {
        TryGetComponent<Character>(out character);
    }

    public void ApplyStatusEffect(SO_StatusEffectData effectData)
    {
        if (activeStatusEffects.ContainsKey(effectData.Effect)) return;

        int applyChance = Random.Range(0, 100);
        if (applyChance > effectData.ApplyChance) return;

        StatusEffect effect = null;

        switch (effectData.Effect)
        {
            case None:
                print("No status effect");
                break;
            case Burn:
                effect = new StatusEffect_DOT(effectData, this, character.health);
                break;
            case Poison:
                effect = new StatusEffect_DOT(effectData, this, character.health);
                break;
            case IncreaseMaxHealth:
                effect = new StatusEffect_MaxHealth(effectData, this, character.stat);
                break;
            case DecreaseMaxHealth:
                effect = new StatusEffect_MaxHealth(effectData, this, character.stat);
                break;
            case Stun:
                effect = new StatusEffect_Stun(effectData, this, character.stat);
                break;
        }

        if (effect != null)
        {
            ApplyStatusEffectEvent?.Invoke(effectData);
            activeStatusEffects.Add(effectData.Effect, effect);
            StartCoroutine(effect.ApplyEffect());
        }
    }
    public void RemoveStatusEffect(SO_StatusEffectData effectData)
    {
        RemoveStatusEffectEvent?.Invoke(effectData);
        activeStatusEffects.Remove(effectData.Effect);
    }
}
