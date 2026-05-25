using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy")]

public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float maxHealth;
    public float damage;
    public string attackType;
    public Sprite portrait;
    public GameObject enemyPrefab;
    public int value;
    public int xpValue;
    public bool isMiniboss;
    public bool isBoss;
    public int enemyCount = 1;
}
