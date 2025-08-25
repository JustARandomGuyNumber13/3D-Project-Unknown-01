using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Stat))]
public class Health : MonoBehaviour
{
    Stat stat;
    WaitForSeconds autoRespawn;
    float maxHealth;

    public UnityEvent<float> OnSetUpEvent;
    public UnityEvent<float> OnHealthChangeEvent;
    public UnityEvent OnHealthDecreaseEvent;
    public UnityEvent<Stat> OnDieEvent;

    private void Awake()
    {
        TryGetComponent<Stat>(out stat);
    }
    private void Start()
    { 
        OnSetUpEvent?.Invoke(stat.CurrentHealth);
        maxHealth = stat.CurrentHealth;
    }


    public void TakeDamage(float damageAmount)
    {
        if (!stat.IsAlive) return;

        stat.CurrentHealth -= damageAmount;
        OnHealthChangeEvent?.Invoke(stat.CurrentHealth);

        if (stat.CurrentHealth <= 0)
        {
            stat.CurrentHealth = 0;
            stat.IsAlive = false;
            OnDieEvent?.Invoke(stat);
        }  
        else
        {
            OnHealthDecreaseEvent?.Invoke();
        }
    }
    public void TakeDamagePercentage(float percentage)
    {
        float damage = maxHealth * percentage / 100;
        TakeDamage(damage);
    }
}
