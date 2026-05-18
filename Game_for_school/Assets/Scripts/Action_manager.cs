using UnityEngine;

public class Action_manager : MonoBehaviour
{
    private player_stats player_stats;
    private Transform player_transform;
    private Rigidbody2D rb;

    private enemy_stats enemy_stats;

    public float speed;

    public float targetEnemy = 2.24f;
    public float targetOrigin = -5f;

    public bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player_stats = GetComponent<player_stats>();

        player_transform = GetComponent<Transform>();
    }

    void Update()
    {
        if(enemy_stats == null)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

            if(enemy != null)
            {
                enemy_stats = enemy.GetComponent<enemy_stats>();
            }
        }

        if (isAttacking)
        {
            AttackAction();
        }

        if(player_transform.position.x <= targetOrigin && !isAttacking)
        {
            rb.linearVelocity = Vector2.zero;

            rb.position = new Vector2(targetOrigin, rb.position.y);
        }
    }

    public void Attack()
    {
        Debug.Log("Current stamina: " + player_stats.stamina);

        if(enemy_stats == null)
            return;

        if(player_stats.stamina < 10)
        {
            Debug.Log("NOT ENOUGH STAMINA");
            return;
        }

        if(enemy_stats.health <= 0)
            return;

        isAttacking = true;

        player_stats.stamina -= 10;
    }

    public void AttackAction()
    {
        if(player_transform.position.x < targetEnemy)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else
        {
            enemy_stats.health -= player_stats.damage;

            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);

            isAttacking = false;
        }
    }
}