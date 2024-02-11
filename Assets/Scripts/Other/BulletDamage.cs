using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamageEnemy(damage); ;

            Destroy(gameObject);
        }

        else
        {
            //Destroy(gameObject, 2f);
        }

    }
}
