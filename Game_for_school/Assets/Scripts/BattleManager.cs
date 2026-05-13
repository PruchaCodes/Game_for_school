using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public player_stats player_stats;
    public enemy_stats enemy_stats;

    public bool playerTurn = true;

    public void PlayerAttack()
    {
        if (!playerTurn)
        {
            return;
        }

        if(player_stats.stamina < 10)
        {
            Debug.Log("Not enough stamina to attack!");
            return;
        }

        enemy_stats.health -= player_stats.damage;
        player_stats.stamina -= 10;

        playerTurn = false;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(3f);
        
        if(enemy_stats.health > 0)
        {
            player_stats.health -= enemy_stats.damage;
            Debug.Log("Enemy attacks! Player health: " + player_stats.health);
        }
        else
        {
            Debug.Log("Enemy defeated!");
        }

        playerTurn = true;
    }
}
