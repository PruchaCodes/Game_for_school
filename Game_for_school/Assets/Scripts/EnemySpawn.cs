using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    private List<GameObject> currentEnemies = new List<GameObject>();
    private EnemyData currentEnemyData;
    public lvlCounter lvlCounter;

    void Start()
    {
        lvlCounter = GameObject.FindGameObjectWithTag("LevelCounter").GetComponent<lvlCounter>();
        SpawnCurrentEnemy();
    }

    void Update()
    {
        if (lvlCounter == null)
        {
            lvlCounter = GameObject.FindGameObjectWithTag("LevelCounter").GetComponent<lvlCounter>();
        }
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

            stats.maxHealth = currentEnemyData.maxHealth + (lvlCounter.currentLevel == 2 ? 10 : 0) + (lvlCounter.currentLevel == 4 ? 20 : 0) + (lvlCounter.currentLevel == 6 ? 20 : 0) + (lvlCounter.currentLevel == 8 ? 30 : 0);
            stats.health = stats.maxHealth;
            stats.damage = currentEnemyData.damage + lvlCounter.currentLevel;
            stats.isMiniboss = currentEnemyData.isMiniboss;
            stats.isBoss = currentEnemyData.isBoss;
        }
    }

    public IEnumerator EnemyDefeated()
    {
        coinCounter.Instance.AddCoins(currentEnemyData);
        lvlCounter.Instance.currentExp += currentEnemyData.xpValue;        

        yield return new WaitForSeconds(2f);


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