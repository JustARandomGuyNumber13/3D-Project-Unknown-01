using UnityEngine;

[CreateAssetMenu(fileName = "SO_AttackData", menuName = "Skill Data/SO_AttackData")]
public class SO_AttackData : SO_SkillData
{
    [Header("Attack Data")]
    public float DamageAmount;

    [Header("Status Effect")]
    public SO_StatusEffectData[] status;
}
