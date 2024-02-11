using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private float maxHP;

    public float actualHP_player { get; private set; }

    private bool isAlive;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();

        actualHP_player = maxHP;
        isAlive = true;
    }

    public void TakeDamagePlayer(float enemy_damage)
    {
        actualHP_player -= enemy_damage;
        CheakIsAlive_Player();
        Debug.Log("здоровье игрока = " + actualHP_player);
    }

    private void CheakIsAlive_Player()
    {
        if (actualHP_player <= 0)
        {
            isAlive = false;
            anim.SetBool("Dead", true);
        }

        else
        {
            isAlive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Recovery_HP"))
        {
            actualHP_player = maxHP;

            Destroy(collision.gameObject);
        }
    }

    void Deathe()
    {
        if (isAlive == false)
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }
}
