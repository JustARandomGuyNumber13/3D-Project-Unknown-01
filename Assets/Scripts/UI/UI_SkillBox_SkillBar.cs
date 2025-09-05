using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UI_SkillBox_SkillBar : MonoBehaviour, IDropHandler
{
    public UnityEvent<int, SO_SkillData> OnDragItemDropEvent;
    [SerializeField] int skillIndex;
    [SerializeField] UI_Skill_DragItem dragItem;
    public Image skillImage;

    public void UpdateUI(SO_SkillData data)
    { 
        if(data == null)
            skillImage.sprite = null;
        else
            skillImage.sprite = data.skillIcon;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData == null) return;

        OnDragItemDropEvent?.Invoke(skillIndex, dragItem.SkillData);
    }
}
