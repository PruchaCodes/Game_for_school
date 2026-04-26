using UnityEngine;
using System.Collections;

public class enemy_type1_action_manager : MonoBehaviour
{
    [SerializeField] private Enemy_script_goblin enemy_script_goblin;
    [SerializeField] private Transform goblin_transform;

    public float speed;
    public float targetEnemy = -1.24f;
    public float targetOrigin = 5f;

    private Rigidbody2D rb;
    public bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && enemy_script_goblin.health > 0 && !isAttacking)
        {
            StartCoroutine(AttackSequence());
        }
    }

    private IEnumerator AttackSequence()
    {
        yield return new WaitForSeconds(2f);
        isAttacking = true;

        // Move to player
        while (Mathf.Abs(goblin_transform.position.x - targetEnemy) > 0.05f)
        {
            float dir = Mathf.Sign(targetEnemy - goblin_transform.position.x);
            rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);
            yield return new WaitForFixedUpdate();
        }

        rb.linearVelocity = Vector2.zero;

        // wait before going back

        // Return to origin
        while (Mathf.Abs(goblin_transform.position.x - targetOrigin) > 0.05f)
        {
            float dir = Mathf.Sign(targetOrigin - goblin_transform.position.x);
            rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);
            yield return new WaitForFixedUpdate();
        }

        rb.linearVelocity = Vector2.zero;
        isAttacking = false;
    }
}