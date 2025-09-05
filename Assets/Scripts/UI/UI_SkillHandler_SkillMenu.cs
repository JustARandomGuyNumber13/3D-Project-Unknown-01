using UnityEngine;
using UnityEngine.EventSystems;


public class UI_SkillHandler_SkillMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] SO_SkillList skillDataList;
    [SerializeField] Transform contentHolder;   // Set prefab's parent
    [SerializeField] UI_SkillBox_SkillMenu prefab;
    [SerializeField] UI_Skill_DragItem dragObject;

    RectTransform drag;

    bool isDragging = false;

    private void Start()
    {
        drag = dragObject.SkillSprite.rectTransform;
        SetupSkillMenu();
    }

    #region Ignore, call by UI_SkillBox_SkillMenu.cs
    public void StartDragging(SO_SkillData skillData, Vector3 position)
    {
        if (isDragging) return;

        isDragging = true;
        dragObject.StartDragging(skillData, position);
    }
    public void Dragging(PointerEventData eventData)
    {
        drag.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void EndDragging()
    {
        isDragging = false;
        dragObject.EndDragging();
    }
    #endregion

    private void SetupSkillMenu()
    {
        foreach (var skillData in skillDataList.SkillList)
        {
            var skillBox = Instantiate(prefab, contentHolder);
            skillBox.SetUpSkillBox(skillData, this);
        }
    }
}
