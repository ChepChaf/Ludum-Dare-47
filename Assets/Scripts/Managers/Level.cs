using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels/Create Level")]
public class Level : ScriptableObject
{
    // Coins Config
    public int coinsCount;

    // Enemies Config
    public int enemiesCount;
    public float spawnOffset;
}