using UnityEngine;

[CreateAssetMenu(fileName = "SO_Stat", menuName = "Scriptable Objects/SO_Stat")]
public class SO_Stat : ScriptableObject
{
    [Header("Base Stat")]
    public int MaxHealth;
}