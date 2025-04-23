using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    float move;

    [SerializeField] float JumpForce;
    [SerializeField] bool IsJumping;

    Rigidbody2D rb2d;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        move = Input.GetAxis("Horizontal");

        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);

        //Jump
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));

            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
}
