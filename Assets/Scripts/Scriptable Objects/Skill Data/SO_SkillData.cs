using UnityEngine;

[CreateAssetMenu(fileName = "SO_SkillData", menuName = "Skill Data/SO_SkillData")]
public class SO_SkillData : ScriptableObject
{
    [Header("Base")]
    public float IsCanUseSkillCooldownDuration;
    public float DelayDuration;
    public float ActiveDuration;
    public float CooldownDuration;
}

//[CreateAssetMenu(fileName = "SO_StatusEffectData", menuName = "Skill Data/SO_StatusEffectData")]

