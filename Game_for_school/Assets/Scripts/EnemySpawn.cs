using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    private List<GameObject> currentEnemies = new List<GameObject>();
    private int value;

    void Start()
    {
        EnemyData enemy = ProgressionManager.Instance.GetCurrentEnemy();
        SpawnEnemy(enemy.enemyCount);
    }

    public void SpawnEnemy(int amount)
{
    EnemyData enemyData = ProgressionManager.Instance.GetCurrentEnemy();

    for(int i=0;i<amount;i++)
    {
        Vector3 pos = transform.position;

        pos.x += i * 2f;

        GameObject enemy = Instantiate(enemyData.enemyPrefab, pos, Quaternion.identity);
        currentEnemies.Add(enemy);

        enemy_stats stats = enemy.GetComponent<enemy_stats>();

        stats.maxHealth = enemyData.maxHealth;

        stats.health = enemyData.maxHealth;

        stats.damage = enemyData.damage;

        stats.isMiniboss = enemyData.isMiniboss;

        stats.isBoss = enemyData.isBoss;
    }
}

    public IEnumerator EnemyDefeated()
    {
        
        yield return new WaitForSeconds(2f);

        coinCounter.Instance.AddCoins(value);
        foreach(GameObject enemy in currentEnemies)
        {
            if(enemy != null)
            {
                Destroy(enemy);
            }
        }

        currentEnemies.Clear();
        

        ProgressionManager.Instance.AdvanceEnemy();

        SpawnEnemy(ProgressionManager.Instance.GetCurrentEnemy().enemyCount);
    }
}