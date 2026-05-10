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
}
