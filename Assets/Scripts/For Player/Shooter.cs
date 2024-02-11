using UnityEngine.UI;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Настройка атак:")]
    [SerializeField] private GameObject [] bullets;    
    [SerializeField] private Transform [] firePoints;
    [SerializeField] private AudioSource [] clips;
    [SerializeField] private float fireSpeed;

    [SerializeField] private float maxMana;
    public float actualMana { get; private set; }
    //private float manaCoast;

    [Header("Кнопки аттак:")]
    [SerializeField] private Button [] attackBtn;

    private Animator anim;
    private PlayerMove playerMove;

    private void Start()
    {
        anim = GetComponent<Animator>();

        playerMove = GetComponent<PlayerMove>();

        actualMana = maxMana;
    }

    void BasicAttac()
    {
        float frstAttCoast = 10;

        if (actualMana >= frstAttCoast)
        {
            GameObject currentBullet = Instantiate(bullets[0], firePoints[0].position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

            if (playerMove.faceRight)
            {
                currentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currentBulletVelocity.velocity.y);
            }

            else
            {
                currentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currentBulletVelocity.velocity.y);
                currentBullet.transform.localScale *= new Vector2(-1, 1);
            }

            clips[0].Play();

            anim.SetBool("Attack1", false);

            actualMana -= frstAttCoast;

            Destroy(currentBullet, 1.5f);
        }

        else 
        {
            anim.SetBool("Attack1", false);
            //attackBtn[0].interactable = false;
        }
    }

    void SecondAttack() 
    {
        float scndAttCoast = 40;

        if (actualMana >= scndAttCoast)
        {
            GameObject currentBullet = Instantiate(bullets[1], firePoints[1].position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

            if (playerMove.faceRight)
            {
                currentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currentBulletVelocity.velocity.y);
            }

            else
            {
                currentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currentBulletVelocity.velocity.y);
                currentBullet.transform.localScale *= new Vector2(-1, 1);
            }

            clips[1].Play();

            anim.SetBool("Attack2", false);

            actualMana -= scndAttCoast;

            Destroy(currentBullet, 0.7f);
        }

        else 
        {
            anim.SetBool("Attack2", false);
            //attackBtn[1].interactable = false;
        }
        
    }

    void ThirdAttack()
    {
        float thrdAttCoast = 80;

        if (actualMana >= thrdAttCoast)
        {
            GameObject currentBullet = Instantiate(bullets[2], firePoints[2].position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

            if (playerMove.faceRight)
            {
                currentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currentBulletVelocity.velocity.y);
            }

            else
            {
                currentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currentBulletVelocity.velocity.y);
                currentBullet.transform.localScale *= new Vector2(-1, 1);
            }

            clips[2].Play();

            anim.SetBool("Attack3", false);

            actualMana -= thrdAttCoast;

            Destroy(currentBullet, 2f);
        }

        else 
        {
            anim.SetBool("Attack3", false);
            //attackBtn[2].interactable = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Recovery_Mana"))
        {
            actualMana = maxMana;

            Destroy(collision.gameObject);
        }
    }

    public void BasicAttackStart() 
    {
        anim.SetBool("Attack1", true);
        
    }

    public void SecondAttackStart()
    {
        anim.SetBool("Attack2", true);
    }

    public void ThirdAttackStart()
    {
        anim.SetBool("Attack3", true);
    }
}
