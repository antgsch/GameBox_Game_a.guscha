using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyBullet")) 
        {
            Destroy(gameObject);
        }
    }
}
