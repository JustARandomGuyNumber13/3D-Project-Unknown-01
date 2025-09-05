using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    [SerializeField] GameObject SkillScriptsHolder;
    [SerializeField] DamageCollider[] damageColliders;
    [SerializeField] UI_SkillBox_SkillBar[] ui;

    private SO_SkillData[] skillSlots = new SO_AttackData[5];
    private Dictionary<SO_AttackData.ColliderType, List<DamageCollider>> cachedCollidersByType = new();


    private void Start()
    {
        foreach (var u in ui)
            u.OnDragItemDropEvent.AddListener(ChangeSkill);
        InitializeDamageColliders();
    }

    public void UseSkill(Stat userStat, int index)
    {
        // Check user's status
        if (!userStat.IsCanUseSkill || userStat.IsStun) return;
        if (skillSlots[index] == null) return;

        // Search for skill's behavior script
        Type skillType = skillSlots[index].SkillBehavior.GetClass();
        SkillScriptsHolder.TryGetComponent(skillType, out var skillBehavior);

        // Double check before proceed to the next step
        if (skillBehavior == null || (skillBehavior is not Skill)) return;

        // Activate skill
        (skillBehavior as Skill).Activate(userStat, skillSlots[index], this);
    }
    public void ChangeSkill(int skillBoxIndex, SO_SkillData skillData)
    {
        // Error check
        if (skillBoxIndex < 0 || skillBoxIndex > skillSlots.Length)
            return;

        if (skillSlots[skillBoxIndex] == skillData) return;

        if (skillData == null)
        {
            skillSlots[skillBoxIndex] = null;
            UpdateSkillSlotUI(skillBoxIndex);
            return;
        }

        // Change or swap skill
        if (skillSlots.Contains(skillData))
        {
            SwapSkill(skillBoxIndex, Array.IndexOf(skillSlots, skillData));
        }
        else
        {
            skillSlots[skillBoxIndex] = skillData;
            UpdateSkillSlotUI(skillBoxIndex);
        }
    }
    private void SwapSkill(int currentIndex, int replaceIndex)
    {
        var temp = skillSlots[currentIndex];

        skillSlots[currentIndex] = skillSlots[replaceIndex];
        UpdateSkillSlotUI(currentIndex);
        
        skillSlots[replaceIndex] = temp;
        UpdateSkillSlotUI(replaceIndex);
    }
    private void UpdateSkillSlotUI(int index)
    {
        if (ui != null)
            ui[index].UpdateUI(skillSlots[index]);
    }

    private void InitializeDamageColliders()
    {
        cachedCollidersByType.Clear();
        foreach (var c in damageColliders)
        {
            foreach (var type in c.Type)
            {
                if (!cachedCollidersByType.ContainsKey(type))
                    cachedCollidersByType[type] = new List<DamageCollider>();
                
                cachedCollidersByType[type].Add(c);
            }
        }
    }
    public DamageCollider[] GetDamageColliders(SO_AttackData.ColliderType type)
    {
        if (cachedCollidersByType.TryGetValue(type, out var colliders))
            return colliders.ToArray();
        return null;
    }
}
