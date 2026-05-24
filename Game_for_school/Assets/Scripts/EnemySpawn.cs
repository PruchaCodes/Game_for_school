using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    private List<GameObject> currentEnemies = new List<GameObject>();
    private EnemyData currentEnemyData;

    void Start()
    {
        SpawnCurrentEnemy();
    }

    public void SpawnCurrentEnemy()
    {
        currentEnemyData = ProgressionManager.Instance.GetCurrentEnemy();

        for (int i = 0; i < currentEnemyData.enemyCount; i++)
        {
            Vector3 pos = transform.position;
            pos.x += i * 2f;

            GameObject enemy = Instantiate(
                currentEnemyData.enemyPrefab,
                pos,
                Quaternion.identity
            );

            currentEnemies.Add(enemy);

            enemy_stats stats = enemy.GetComponent<enemy_stats>();

            stats.maxHealth = currentEnemyData.maxHealth;
            stats.health = currentEnemyData.maxHealth;
            stats.damage = currentEnemyData.damage;
            stats.isMiniboss = currentEnemyData.isMiniboss;
            stats.isBoss = currentEnemyData.isBoss;
        }
    }

    public IEnumerator EnemyDefeated()
    {
        yield return new WaitForSeconds(2f);

        coinCounter.Instance.AddCoins(currentEnemyData);

        foreach (GameObject enemy in currentEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }

        currentEnemies.Clear();

        ProgressionManager.Instance.AdvanceEnemy();

        SpawnCurrentEnemy();
    }
}