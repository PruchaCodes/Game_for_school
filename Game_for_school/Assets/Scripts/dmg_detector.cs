using UnityEngine;

public class dmg_detector : MonoBehaviour
{
    [SerializeField] private player_stats player_stats;
    [SerializeField] private Enemy_script_goblin enemy_script_goblin;

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
        if (collider.CompareTag("Player") && enemy_script_goblin.health > 0)
        {
            enemy_script_goblin.health -= player_stats.damage;
            player_stats.stamina -= 10;
            
        }
       
        
    }
   
}
