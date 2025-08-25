using UnityEngine;

[CreateAssetMenu(fileName = "SO_Stat", menuName = "Scriptable Objects/SO_Stat")]
public class SO_Stat : ScriptableObject
{
    [Header("Base Stat")]
    public int MaxHealth;
}

[CreateAssetMenu(fileName = "SO_PlayerStat", menuName = "Scriptable Objects/SO_PlayerStat")]
public class  SO_PlayerStat : SO_Stat
{
    [Header("Z axis speed")]
    public float zForwardAcceleration;
    public float zBackwardAcceleration;
    public float zForwardSpeed;
    public float zBackwardSpeed;

    [Header("X axis speed")]
    public float xAcceleration;
    public float xForwardSpeed;
    public float xBackwardSpeed;
}
