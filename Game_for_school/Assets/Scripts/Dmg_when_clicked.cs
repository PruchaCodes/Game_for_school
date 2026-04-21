using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Dmg_when_clicked : MonoBehaviour

{
    [SerializeField] private player_stats player_stats;
    public int dmgOnClick, healOnClick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Dmg on click active");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dmg();
        }else if (Input.GetMouseButtonDown(1))
        {
            heal();
        }
    }

    private void dmg()
    {
        if(player_stats.health > 0){
            player_stats.health -= dmgOnClick;
            Debug.Log("Player has taken:" + dmgOnClick + " damage");
            Debug.Log("Player health is now:" + player_stats.health);
        }
    }

    private void heal()
    {
        if(player_stats.health < player_stats.maxHealth){
            player_stats.health += healOnClick;

            if(player_stats.health > player_stats.maxHealth){
                player_stats.health = player_stats.maxHealth;
                
            }
            
            Debug.Log("Player has been healed by:" + healOnClick + " health");
            Debug.Log("Player health is now:" + player_stats.health);
            
            
        }
    }


}
