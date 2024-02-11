using UnityEngine;

public class Lift : MonoBehaviour
{
    private SliderJoint2D platform;
    private JointMotor2D motor;

    void Start()
    {
        platform = GetComponent<SliderJoint2D>();
        motor = platform.motor;
        motor.motorSpeed = 0;
        platform.motor = motor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            motor = platform.motor;
            motor.motorSpeed = 1;
            platform.motor = motor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            motor = platform.motor;
            motor.motorSpeed = -1;
            platform.motor = motor;
        }
    }
}
