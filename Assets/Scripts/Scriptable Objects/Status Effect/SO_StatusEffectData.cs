using UnityEngine;

[CreateAssetMenu(fileName = "SO_StatusEffectData", menuName = "Status Effect Data/SO_StatusEffectData")]
public class SO_StatusEffectData : ScriptableObject
{
    public Sprite EffectSprite;
    public EffectType Effect = EffectType.None;
    public float Duration;
    [Range(0, 100)] public int ApplyChance;

    public enum EffectType
    {
        None,
        Burn,
        Freeze,
        Poison,
        Stun,
        IncreaseMaxHealth,
        DecreaseMaxHealth
    }
}