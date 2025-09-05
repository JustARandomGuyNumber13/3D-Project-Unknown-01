using UnityEngine;
using UnityEngine.UI;

public class UI_Skill_DragItem : MonoBehaviour
{
    public Image SkillSprite;
    public SO_SkillData SkillData { get; private set; }
    [SerializeField] CanvasGroup cg;

    // Call by UI_SkillHandler_SkillMenu.cs
    public void StartDragging(SO_SkillData skillData, Vector3 startPos)
    {
        SkillData = skillData;
        SkillSprite.sprite = skillData.skillIcon;
        SkillSprite.rectTransform.position = startPos;
        gameObject.SetActive(true);
        cg.interactable = false;
    }
    public void EndDragging()
    { 
        cg.interactable = true;
        gameObject.SetActive(false);
    }
}
