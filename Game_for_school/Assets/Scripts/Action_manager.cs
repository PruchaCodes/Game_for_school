
using Unity.VisualScripting;
using UnityEngine;


public class Action_manager : MonoBehaviour
{

    private player_stats player_stats;
    private Transform player_transform;
    public float speed;
    public float targetEnemy = 2.24f, targetOrigin = -5f;
    private Rigidbody2D rb;
    public bool isAttacking = false;
    private enemy_stats enemy_stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player_stats = GetComponent<player_stats>();
        player_transform = GetComponent<Transform>();
        enemy_stats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemy_stats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Keypad1) && Mathf.Abs(player_transform.position.x - targetOrigin) < 0.05f && player_stats.stamina > 0 && enemy_stats.health > 0 && player_stats.health > 0)
        {
            isAttacking = true;
        }*/

        if (isAttacking)
        {
            AttackAction();
        }

        if(player_transform.position.x <= targetOrigin && !isAttacking)
        {
            rb.linearVelocity = Vector2.zero;
            rb.position = new Vector2(targetOrigin, rb.position.y);
        }

        /*if (Input.GetKeyDown(KeyCode.Keypad2) && !isAttacking)
        {
            StaminaRegen();
        }*/
        
    }

    public void AttackAction()
    {
        if(player_transform.position.x < targetEnemy)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            
        }else if(player_transform.position.x >= targetEnemy)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            isAttacking = false;
            
        }
        
    }

    public void Attack()
    {
        if (Mathf.Abs(player_transform.position.x - targetOrigin) < 0.05f && player_stats.stamina > 0 && enemy_stats.health > 0 && player_stats.health > 0)
        {
            isAttacking = true;
        }
    }

    public void StaminaRegen()
    {
        if(player_stats.stamina < player_stats.maxStamina)
        {
            player_stats.stamina += 5;
            if(player_stats.stamina > player_stats.maxStamina)
            {
                player_stats.stamina = player_stats.maxStamina;
            }
        }
    }
}
