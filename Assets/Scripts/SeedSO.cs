using UnityEngine;

[CreateAssetMenu(fileName = "SeedSO", menuName = "Scriptable Objects/SeedSO")]
public class SeedSO : ScriptableObject
{
    public SeedType type;
    public Transform crop;
    public int coinCost;
}
