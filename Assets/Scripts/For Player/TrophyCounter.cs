using UnityEngine.UI;
using UnityEngine;

public class TrophyCounter : MonoBehaviour
{
    [SerializeField] private Text countText;
    [SerializeField] private Text runeText;
    private float numberCoin;
    private float numberRune;

    void Start()
    {
        numberCoin = 0;
        numberRune = 0;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) 
        {
            numberCoin++;

            Destroy(collision.gameObject);

            countText.text = numberCoin.ToString();
        }

        else if (collision.gameObject.CompareTag("Rune"))
        {
            numberRune++;

            Destroy(collision.gameObject);

            runeText.text = numberRune.ToString();
        }
    }
}
