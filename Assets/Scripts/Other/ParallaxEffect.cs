using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] GameObject cam;

    [SerializeField] private float coeff;
    private float startPosX;

    private void Start()
    {
        startPosX = transform.position.x;
    }

    private void LateUpdate()
    {
        float distX = (cam.transform.position.x * (1 - coeff));

        transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position.z);
    }
}
