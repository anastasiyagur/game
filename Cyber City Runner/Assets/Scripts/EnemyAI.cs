using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float enemySpeed = 3.5f;
    [SerializeField] private float chaseDistance = 5.0f;
    [SerializeField] private float attackDistance = 4.0f;
    [SerializeField] private float attackDamage = 10.0f;
    [SerializeField] private float attackRate = 1.0f; 

    private Vector3 startPos;
    private float lastAttackTime; 
    private PlayerCharacter playerHealth;
    private bool isChasing;

    void Start()
    {
        startPos = transform.position;
        playerHealth = player.GetComponent<PlayerCharacter>();

        if (playerHealth == null)
        {
            Debug.LogError("PlayerCharacter script not found on the player object.");
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distance to player: " + distance);
        if (distance <= chaseDistance)
        {
            Chase();
            Debug.Log("ahhhh0");

            if (distance <= attackDistance)
            {
                Debug.Log("ahhhh");
                AttackPlayer();  
            }
        }
        else
        {
            StopChase();
        }
    }

    void Chase()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; 

        transform.position += direction * enemySpeed * Time.deltaTime;
        isChasing = true;
    }

    void StopChase()
    {
        if (isChasing)
        {
            Vector3 direction = (startPos - transform.position).normalized;
            transform.Translate(0, 0, enemySpeed * Time.deltaTime);
            isChasing = false;
        }
    }

    void AttackPlayer()
    {
        Debug.Log("ahhhh2");
            if (playerHealth != null)
            {
            Debug.Log("ahhhh3");

            playerHealth.TakeDamage(attackDamage);
                Debug.Log("Attacked player for " + attackDamage + " damage."); 
                lastAttackTime = Time.time;
            }
    }
}

