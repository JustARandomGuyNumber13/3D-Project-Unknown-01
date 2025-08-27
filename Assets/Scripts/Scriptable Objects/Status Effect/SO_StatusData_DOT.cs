using UnityEngine;

[CreateAssetMenu(fileName = "SO_StatusData_DOT", menuName = "Status Effect Data/SO_StatusData_DOT")]
public class SO_StatusData_DOT : SO_StatusEffectData
{
    [Header("DOT Status Data")]
    public bool IsPercentage;
    public float DamagePerTick;
    public float TickInterval;
}
