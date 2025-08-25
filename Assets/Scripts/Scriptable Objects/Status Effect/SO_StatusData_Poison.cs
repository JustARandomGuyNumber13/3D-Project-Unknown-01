using UnityEngine;

[CreateAssetMenu(fileName = "SO_StatusData_Poison", menuName = "Status Effect Data/SO_StatusData_Poison")]
public class SO_StatusData_Poison : SO_StatusEffectData
{
    [Header("Poison Status Data")]
    public bool IsPercentage;
    public float DamagePerTick;
    public float TickInterval;
}