using UnityEngine.UI;
using UnityEngine;

public class OpenAttack : MonoBehaviour
{
    [SerializeField] private Button attackBtn;

    private void Start()
    {
        attackBtn.interactable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            attackBtn.interactable = true;
        }

        Destroy(gameObject, 0.5f);
    }
}
