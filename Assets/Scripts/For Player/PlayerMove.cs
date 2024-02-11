using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Настройки для передвижения")]
    [SerializeField] private float moveSpeed;
    public bool faceRight;

    [Header("Настройки для прыжка")]
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform GroundCheakPosition;
    [SerializeField] private float radiusCheak;
    [SerializeField] private LayerMask groundLayer;
    private bool onGround;


    private Rigidbody2D plrRgbd;
    private Animator anim;
    private Vector2 moveVector;

    void Start()
    {
        plrRgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        faceRight = true;
        onGround = true;
    }

    void Update()
    {
        Flip();
        Jump();
        Run();
    }
    private void FixedUpdate()
    {
        Walk();
        GroundCheaking();
    }

    void Walk() 
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));

        plrRgbd.velocity = new Vector2(moveVector.x * moveSpeed, plrRgbd.velocity.y);
    }

    void Run() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 2;                     
            anim.SetBool("Run", true);
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= 2;
            anim.SetBool("Run", false);
        }
    }

    void Flip() 
    {
        if (moveVector.x > 0 && !faceRight || moveVector.x < 0 && faceRight) 
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void Jump() 
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            plrRgbd.AddForce(Vector2.up * jumpForce);
        }
    }

    void GroundCheaking() 
    {
        onGround = Physics2D.OverlapCircle(GroundCheakPosition.position, radiusCheak, groundLayer);
        anim.SetBool("Jump", onGround);
    }
}
