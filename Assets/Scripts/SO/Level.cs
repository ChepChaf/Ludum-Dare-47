using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels/Create Level")]
public class Level : ScriptableObject
{
    [Header("Coins")]
    public int coinsCount;

    [Header("Enemies")]
    public int enemiesCount;
    public float spawnOffset;
    
    public GameObject trajectory;
}