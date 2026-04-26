using UnityEngine;

public class dmg_detector : MonoBehaviour
{
    [SerializeField] private player_stats player_stats;
    [SerializeField] private Enemy_script_goblin enemy_script_goblin;
    [SerializeField] private Action_manager action_manager;
    [SerializeField] private enemy_type1_action_manager enemy_action_manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && enemy_script_goblin.health > 0 && action_manager.isAttacking && player_stats.stamina > 0)
        {
            enemy_script_goblin.health -= player_stats.damage;
            player_stats.stamina -= 10;
            
        }
       
       if (collider.CompareTag("Player") && player_stats.health > 0 && enemy_action_manager.isAttacking)
        {
            player_stats.health -= enemy_script_goblin.damage;
            
            
        }
        
    }
   
}
