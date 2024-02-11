using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToReverse;
    private Animator animEnemy;
    private Rigidbody2D body;

    private bool faceRight;
    private float currentState;
    private float currentTimeToReverse;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERSE_STATE = 2;
    private const float ATTACK_STATE = 3;


    private void Start()
    {
        faceRight = false;

        animEnemy = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        currentState = WALK_STATE;
        currentTimeToReverse = 0;
    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemys_Stopper"))
        {
            currentState = IDLE_STATE;                        
        }    
        
        else if (collision.gameObject.CompareTag("Player"))
        {
            currentState = ATTACK_STATE;

            animEnemy.SetBool("Attack", true);
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }


    void Flip()
    {
        if (!faceRight || faceRight)
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void Movement() 
    {
        if (currentTimeToReverse >= timeToReverse)
        {
            currentTimeToReverse = 0;
            currentState = REVERSE_STATE;
        }

        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToReverse += Time.deltaTime;
                animEnemy.SetBool("Walk", false);
                break;

            case WALK_STATE:
                body.AddForce(Vector2.right * speed);
                animEnemy.SetBool("Walk", true);
                break;

            case REVERSE_STATE:
                speed *= -1;
                Flip();
                currentState = WALK_STATE;
                break;

            case ATTACK_STATE:
                currentState = IDLE_STATE;
                //animEnemy.SetBool("Attack", true);
                break;
        }
    }

    void Dead() 
    {
       animEnemy.SetBool("Dead", true);
        Destroy(gameObject);


    }
}
