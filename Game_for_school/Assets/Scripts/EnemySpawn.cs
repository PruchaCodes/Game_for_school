using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    private GameObject currentEnemy;
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
        Destroy(gameObject);

        ProgressionManager.Instance.AdvanceEnemy();

        SpawnEnemy(ProgressionManager.Instance.GetCurrentEnemy().enemyCount);
    }
}