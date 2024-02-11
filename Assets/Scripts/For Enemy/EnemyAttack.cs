using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float emenyDamage;
    [SerializeField] private float startAttackTime;
    private AudioSource attackSnd;
    private float timeBtwAtt;
    private PlayerHealth player;
    private Animator animEnemy;


    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        animEnemy = GetComponent<Animator>();
        attackSnd = GetComponent<AudioSource>();
        timeBtwAtt = startAttackTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timeBtwAtt <= 0)
            {
                animEnemy.SetBool("Attack", true);
            }

            else 
            {
                timeBtwAtt -= Mathf.Abs(Time.deltaTime);
                //animEnemy.SetBool("attack", false);
            }
        }
    }


    void Attack()
    {
        Debug.Log("Атака была!");

        attackSnd.Play();

        animEnemy.SetBool("Attack", false);
        timeBtwAtt = startAttackTime;

        player.TakeDamagePlayer(emenyDamage);
    }
}
