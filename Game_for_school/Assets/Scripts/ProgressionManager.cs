using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager Instance;

    public List<EnemyData> enemyProgression = new List<EnemyData>();

    public int currentEnemyIndex = 0;

    void Awake()
    {
        Instance = this;
    }

    public EnemyData GetCurrentEnemy()
    {
        return enemyProgression[currentEnemyIndex];
    }

    public void AdvanceEnemy()
    {
        currentEnemyIndex++;
    }
}