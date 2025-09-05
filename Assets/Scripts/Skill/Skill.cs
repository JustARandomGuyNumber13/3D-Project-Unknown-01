using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Skill : MonoBehaviour
{
    public bool IsReady { get; set; } = true;
    protected SO_SkillData data;
    protected Stat stat;
    protected SkillHandler handler;

    public UnityEvent OnSkillDelayEvent;
    public UnityEvent OnSkillActiveEvent;
    public UnityEvent OnSkillEndEvent;

    public virtual void Activate(Stat stat, SO_SkillData data, SkillHandler handler)
    {
        this.stat = stat;
        this.data = data;
        this.handler = handler;
        if (!stat.IsCanUseSkill || !IsReady) return;
        stat.IsCanUseSkillCooldown(data.IsCanUseSkillCooldownDuration);

        OnConvertSkillData();
        StartCoroutine(ActivateCoroutine());
    }
    IEnumerator ActivateCoroutine()
    {
        IsReady = false;

        OnSkillDelay();
        if (data.DelayDuration > 0)
            yield return new WaitForSeconds(data.DelayDuration);

        OnSkillActive();

        if (data.ActiveDuration > 0)
            yield return new WaitForSeconds(data.ActiveDuration);
        
        OnSkillEnd();
        if(data.CooldownDuration > 0)
            yield return new WaitForSeconds(data.CooldownDuration);

        IsReady = true;
    }

    protected virtual void OnConvertSkillData() { }
    protected virtual void OnSkillDelay() { OnSkillDelayEvent?.Invoke(); }
    protected virtual void OnSkillActive() { OnSkillActiveEvent?.Invoke(); }
    protected virtual void OnSkillEnd() { OnSkillEndEvent?.Invoke(); }
}
