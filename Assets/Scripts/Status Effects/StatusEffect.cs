using System.Collections;
using UnityEngine;

public abstract class StatusEffect
{
    protected MonoBehaviour context;
    protected SO_StatusEffectData effectData;

    public StatusEffect(SO_StatusEffectData effectData, MonoBehaviour context)
    {
        this.effectData = effectData;
        this.context = context;
    }

    public abstract IEnumerator ApplyEffect();
}