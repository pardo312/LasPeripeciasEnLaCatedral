using UnityEngine;

[CreateAssetMenu(fileName = "PickableFallingItem", menuName = "ScriptableObjects/PickableFallingItem", order = 1)]
public class PickableFallingItem : FallingItem
{
    public int amountToCollect;
    public float pickupWeight;
}