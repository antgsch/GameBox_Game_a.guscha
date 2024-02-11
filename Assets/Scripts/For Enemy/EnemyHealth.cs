using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHP;

    public float actualHP_enemy { get; private set; }

    private bool isAlive;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();

        actualHP_enemy = maxHP;
        isAlive = true;
    }

    public void TakeDamageEnemy(float player_damage)
    {
        actualHP_enemy -= player_damage;
        CheakIsAlive_Enemy();
        //Debug.Log("здоровье врага = " + actualHP_enemy);
    }

    private void CheakIsAlive_Enemy()
    {
        if (actualHP_enemy <= 0)
        {
            isAlive = false;
            anim.SetBool("Dead", true);
        }

        else
        {
            isAlive = true;
        }
    }

    void Deathe() 
    {
        if (isAlive == false)
        {
            Destroy(this.gameObject);
        }
    }
}
