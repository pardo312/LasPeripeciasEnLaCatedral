using UnityEngine;

[CreateAssetMenu(fileName = "FallingItem", menuName = "ScriptableObjects/FallingItem", order = 1)]
public class FallingItem : ScriptableObject
{
    public Sprite sprite;
    public float fallingSpeed;
    public int amountToCollect;
    public float pickupWeight;
}