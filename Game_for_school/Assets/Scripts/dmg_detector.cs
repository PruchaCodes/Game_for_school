using UnityEngine;

public class dmg_detector : MonoBehaviour
{
    private player_stats player_stats;
    private enemy_stats enemy_stats;
    private Action_manager action_manager;
    private enemy_type1_action_manager enemy_action_manager;

    void Start()
    {
        enemy_stats = GetComponent<enemy_stats>();
        enemy_action_manager = GetComponent<enemy_type1_action_manager>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player_stats = player.GetComponent<player_stats>();
        action_manager = player.GetComponent<Action_manager>();
        
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && enemy_stats.health > 0 && action_manager.isAttacking && player_stats.stamina > 0)
        {
            enemy_stats.health -= player_stats.damage;
            player_stats.stamina -= 10;
        }

        if (collider.CompareTag("Player") && player_stats.health > 0 && enemy_action_manager.isAttacking)
        {
            player_stats.health -= enemy_stats.damage;
        }
    }
}