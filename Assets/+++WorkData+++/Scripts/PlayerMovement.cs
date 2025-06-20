using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    [Header("Movment")]
    public float movespeed = 5f;

    float horizontalMovement;
    [Header("Jumping")]
    public float jumpPower = 5f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    public CollectablesManager cm;

    public float ScaleValue = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScaleValue = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * movespeed, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded())
        {
            if (context.performed)
            {
                //jump Botton hold = full hight
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            }
            else if (context.canceled)
            {
                //jump Botton quick tab = lower hight
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
        }
        
    }

    private bool isGrounded()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }
        return false;
    }
       
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;  
        Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shrinker"))
        {
            ScaleValue = ScaleValue /2;
            transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.collectableCounter++;
        }
    }
}
