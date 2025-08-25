using UnityEngine;

[CreateAssetMenu(fileName = "SO_StatusEffectData", menuName = "Status Effect Data/SO_StatusEffectData")]
public class SO_StatusEffectData : ScriptableObject
{
    public float Duration;
    public EffectType Effect;
    [Range(0, 100)] public int ApplyChance;

    public enum EffectType
    {
        None,
        Burn,
        Freeze,
        Poison
    }
}