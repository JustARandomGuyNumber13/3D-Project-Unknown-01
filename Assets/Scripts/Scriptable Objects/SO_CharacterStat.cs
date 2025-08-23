using UnityEngine;

[CreateAssetMenu(fileName = "SO_CharacterStat", menuName = "Scriptable Objects/SO_CharacterStat")]
public class SO_CharacterStat : ScriptableObject
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
