using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public Transform spawnPoint;
    

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy_stats enemyStats = spawnedEnemy.GetComponent<enemy_stats>();
        battleManager.enemy_stats = enemyStats;
    }
}
