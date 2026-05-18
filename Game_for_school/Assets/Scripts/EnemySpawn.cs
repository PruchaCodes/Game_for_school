using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    private GameObject currentEnemy;
    private int value;

    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        EnemyData enemyData = ProgressionManager.Instance.GetCurrentEnemy();

        currentEnemy = Instantiate(enemyData.enemyPrefab, transform.position, Quaternion.identity);

        enemy_stats stats = currentEnemy.GetComponent<enemy_stats>();

        stats.maxHealth = enemyData.maxHealth;

        stats.health = enemyData.maxHealth;

        stats.damage = enemyData.damage;
        value = enemyData.value;
        stats.isMiniboss = enemyData.isMiniboss;
        stats.isBoss = enemyData.isBoss;

        if(stats.isMiniboss)
        {
            Debug.Log("Miniboss spawned: " + enemyData.enemyName);
        }
        else if(stats.isBoss)
        {
            Debug.Log("Boss spawned: " + enemyData.enemyName);
        }
        else
        {
            Debug.Log("Enemy spawned: " + enemyData.enemyName);
        }

        
    }

    public IEnumerator EnemyDefeated()
    {
        
        yield return new WaitForSeconds(2f);

        coinCounter.Instance.AddCoins(value);
        Destroy(currentEnemy);

        ProgressionManager.Instance.AdvanceEnemy();

        SpawnEnemy();
    }
}