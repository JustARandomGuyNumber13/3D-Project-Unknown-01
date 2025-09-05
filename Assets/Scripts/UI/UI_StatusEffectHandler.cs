using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatusEffectHandler : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    Dictionary<Sprite, GameObject> effectRecord = new();

    void CreateNewRecord(SO_StatusEffectData effectData) 
    {
        GameObject newStatusBox = Instantiate(prefab, transform);
        Image icon;
        newStatusBox.transform.GetChild(0).TryGetComponent<Image> (out icon);

        if (icon == null) return;

        icon.sprite = effectData.EffectSprite;
        effectRecord.Add(effectData.EffectSprite, newStatusBox);
    }

    public void DeactivateStatus(SO_StatusEffectData effectData) 
    {
        if (!effectRecord.ContainsKey(effectData.EffectSprite)) return;

        effectRecord[effectData.EffectSprite].SetActive(false);
    }

    public void ActivateStatus(SO_StatusEffectData effectData)
    {
        if (effectData.EffectSprite == null) return;

        if (!effectRecord.ContainsKey(effectData.EffectSprite))
            CreateNewRecord(effectData);
        else
            effectRecord[effectData.EffectSprite].SetActive(true);
    }
}
