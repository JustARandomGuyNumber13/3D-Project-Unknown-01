using UnityEngine;

[CreateAssetMenu(fileName = "SO_StatusData_Burn", menuName = "Status Effect Data/SO_StatusData_Burn")]
public class SO_StatusData_Burn : SO_StatusEffectData
{
    [Header("Burn Status Data")]
    public bool IsPercentage;
    public float DamagePerTick;
    public float TickInterval;
}
