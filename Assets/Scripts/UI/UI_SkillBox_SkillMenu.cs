using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SkillBox_SkillMenu : MonoBehaviour
{
    [SerializeField] UI_Drag_Handler skillButton;
    [SerializeField] Image skillImage;
    [SerializeField] TMP_Text skillName;
    UI_SkillHandler_SkillMenu skillHandler;
    SO_SkillData skillData;

    public void SetUpSkillBox(SO_SkillData skillData, UI_SkillHandler_SkillMenu skillHandler)
    {
        skillImage.sprite = skillData.skillIcon;
        skillName.SetText(skillData.skillName);
        this. skillHandler = skillHandler;
        this.skillData = skillData;

        skillButton.OnBeginDragEvent.AddListener(OnBeginDrag);
        skillButton.OnDragEvent.AddListener(OnDrag);
        skillButton.OnEndDragEvent.AddListener(OnEndDrag);
    }
    #region Ignore, call by UI_Drag_Handler.cs 
    private void OnBeginDrag()
    {
        skillHandler.StartDragging(skillData, skillImage.rectTransform.position);
    }
    private void OnDrag(PointerEventData eventData)
    {
        skillHandler.Dragging(eventData);
    }
    private void OnEndDrag()
    {
        skillHandler.EndDragging();
    }
    #endregion
}
