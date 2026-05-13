using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public Transform spawnPoint;
    
    

    void Start()
    {
        
        
    }

    void Update()
    {
        if(battleManager.enemy_stats == null)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy_stats enemyStats = spawnedEnemy.GetComponent<enemy_stats>();
        battleManager.enemy_stats = enemyStats;
    }
}
