using UnityEngine;

public class LadderMove : MonoBehaviour
{
    private Vector2 moveVector;
    private Rigidbody2D player;
    private Animator anim;

    [SerializeField] private float speed;

    private void Start()
    {
        moveVector.y = Input.GetAxis("Vertical");
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ladder"))
        {
            player.gravityScale = 0;

            Debug.Log("Coco Dzambo!");

            if (/*moveVector.y > 0*/ Input.GetKey(KeyCode.W))
            {
                player.velocity = new Vector2(0, speed);

                anim.SetBool("Climb", true);
            }

            else if (/*moveVector.y < 0*/ Input.GetKey(KeyCode.S))
            {
                player.velocity = new(0, -speed);

                anim.SetBool("Climb", true);
            }

            else
            {
                player.velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            player.gravityScale = 2;

            anim.SetBool("Climb", false);
        }
    }
}
