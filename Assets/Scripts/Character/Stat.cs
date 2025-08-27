using System.Collections;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public SO_Stat statData;

    public bool IsStun;
    public bool IsCanMove = true;
    public bool IsCanUseSkill = true;
    public bool IsAlive = true;

    public float CurrentMaxHealth;
    public float CurrentHealth;

    private void Awake()
    {
        CurrentMaxHealth = statData.MaxHealth;
        ResetHealth();
    }

    public void ResetHealth()
    { 
        CurrentHealth = statData.MaxHealth;
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
