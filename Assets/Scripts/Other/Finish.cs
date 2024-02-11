using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
    }

}

