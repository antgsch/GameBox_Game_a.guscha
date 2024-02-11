using UnityEngine;
using UnityEngine.UI;

public class PlayerHP_Bar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Shooter playerShoot;
    [SerializeField] private Image actualHealth;
    [SerializeField] private Image actualMana;

    private void Update()
    {
        actualHealth.fillAmount = playerHealth.actualHP_player / 100;

        actualMana.fillAmount = playerShoot.actualMana / 100;

    }
}
