
using Unity.VisualScripting;
using UnityEngine;


public class Action_manager : MonoBehaviour
{

    public float speed;
    public float targetEnemy = 2.24f, targetOrigin = -5f;
    private Rigidbody2D rb;
    private bool isAttacking = false;
    [SerializeField] private Transform player_transform;
    [SerializeField] private player_stats player_stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && player_transform.position.x == targetOrigin && player_stats.stamina > 0)
        {
            isAttacking = true;
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

    private void AttackAction()
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
}
