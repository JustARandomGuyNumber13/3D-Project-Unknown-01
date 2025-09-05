using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_SkillData", menuName = "Skill Data/SO_SkillData")]
public class SO_SkillData : ScriptableObject
{
    [Header("Base")]
    public string skillName;
    public Sprite skillIcon;
    public MonoScript SkillBehavior; 
    public AnimationClip animationClip;
    public float IsCanUseSkillCooldownDuration;
    public float DelayDuration;
    public float ActiveDuration;
    public float CooldownDuration;
}