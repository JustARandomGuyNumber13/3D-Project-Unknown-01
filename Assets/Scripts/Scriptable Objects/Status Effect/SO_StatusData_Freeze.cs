using UnityEngine;

[CreateAssetMenu(fileName = "SO_StatusData_Freeze", menuName = "Status Effect Data/SO_StatusData_Freeze")]
public class SO_StatusData_Freeze : SO_StatusEffectData
{
    [Header("Freeze Status Data")]
    public bool IsPercentage;
    public float SlowAmount;
}
