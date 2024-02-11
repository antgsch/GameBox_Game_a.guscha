using UnityEngine.UI;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Image actualHealth;

    private void Update()
    {
        actualHealth.fillAmount = enemyHealth.actualHP_enemy / 100;
    }
}
