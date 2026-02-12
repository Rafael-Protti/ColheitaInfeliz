using UnityEngine;

[CreateAssetMenu(fileName = "CropSO", menuName = "Scriptable Objects/CropSO")]
public class CropSO : ScriptableObject
{
    public SeedType croptype;
    public int growthTime;
    public int managementCost;
    public int sellCost;
}
