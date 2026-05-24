using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy")]

public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHealth;
    public int damage;
    public string attackType;
    public Sprite portrait;
    public GameObject enemyPrefab;
    public int value;
    public bool isMiniboss;
    public bool isBoss;
    public int enemyCount = 1;
}
