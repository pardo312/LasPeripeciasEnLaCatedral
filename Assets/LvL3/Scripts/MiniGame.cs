using UnityEngine;

[CreateAssetMenu(fileName = "MiniGame", menuName = "ScriptableObjects/MiniGame", order = 2)]
public class MiniGame : ScriptableObject
{
    public string sceneName;
    public float InitialDuration;
    public int points;
}