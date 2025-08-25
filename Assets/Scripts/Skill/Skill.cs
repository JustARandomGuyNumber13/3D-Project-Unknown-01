using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Skill : MonoBehaviour
{
    public SO_SkillData data;
    protected WaitForSeconds DelayDuration;
    protected WaitForSeconds ActiveDuration;
    protected WaitForSeconds CooldownDuration;

    public bool IsReady = true;

    public UnityEvent OnSkillDelayEvent;
    public UnityEvent OnSkillActiveEvent;
    public UnityEvent OnSkillEndEvent;

    protected virtual void Awake()
    {
        DelayDuration = new WaitForSeconds(data.DelayDuration);
        ActiveDuration = new WaitForSeconds(data.ActiveDuration);
        CooldownDuration = new WaitForSeconds(data.CooldownDuration);
    }

    public virtual void Activate(Stat stat)
    {
        if (!stat.IsCanUseSkill || !IsReady) return;
        stat.IsCanUseSkillCooldown(data.IsCanUseSkillCooldownDuration);
        StartCoroutine(ActivateCoroutine());
    }
    IEnumerator ActivateCoroutine()
    {
        IsReady = false;

        OnSkillDelay();
        if (data.DelayDuration > 0)
            yield return DelayDuration;

        OnSkillActive();
        if(data.ActiveDuration > 0)
            yield return ActiveDuration;

        OnSkillEnd();
        if(data.CooldownDuration > 0)
            yield return CooldownDuration;

        IsReady = true;
    }

    protected virtual void OnSkillDelay() { OnSkillDelayEvent?.Invoke(); }
    protected virtual void OnSkillActive() { OnSkillActiveEvent?.Invoke(); }
    protected virtual void OnSkillEnd() { OnSkillEndEvent?.Invoke(); }
}
