using UnityEngine;

[RequireComponent(typeof(Stat))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(StatusEffectHandler))]
public class Character : MonoBehaviour
{
    [HideInInspector] public Stat stat;
    [HideInInspector] public Health health;
    [HideInInspector] public StatusEffectHandler effectHandler;

    private void Awake()
    {
        TryGetComponent<Stat> (out stat);
        TryGetComponent<Health> (out health);
        TryGetComponent <StatusEffectHandler> (out effectHandler);
    }
}
