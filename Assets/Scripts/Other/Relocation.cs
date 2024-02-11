using UnityEngine;

public class Relocation : MonoBehaviour
{
    [SerializeField] private Transform point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.transform.position = point.position;
        }
    }

}
