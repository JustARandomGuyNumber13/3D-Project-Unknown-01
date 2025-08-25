using System.Collections;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public SO_Stat SO_stat;

    public bool IsCanMove = true;
    public bool IsCanUseSkill = true;
    public bool IsAlive = true;

    public float CurrentHealth;

    private void Awake()
    {
        ResetHealth();
    }

    public void ResetHealth()
    { 
        CurrentHealth = SO_stat.MaxHealth;
    }
    public void IsCanUseSkillCooldown(float duration)
    { 
        StartCoroutine(UseSkillCooldownCoroutine(duration));
    }
    IEnumerator UseSkillCooldownCoroutine(float duration)
    {
        IsCanUseSkill = false;
        yield return new WaitForSeconds(duration);
        IsCanUseSkill = true;
    }
}
