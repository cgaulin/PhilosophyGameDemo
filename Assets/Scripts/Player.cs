using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float speed;
    private Vector2 input;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        input.x = Input.GetAxisRaw("Horizontal") * speed;
        input.y = Input.GetAxisRaw("Vertical") * speed;
        Vector2 playerVelocity = new Vector2(input.x, input.y);
        rb.velocity = playerVelocity;

        bool hasHorizontalSpeed = Mathf.Abs(input.x) > Mathf.Epsilon;
        bool hasVerticalSpeed = Mathf.Abs(input.y) > Mathf.Epsilon;
        if (input != Vector2.zero)
        {
            if (input.x != 0f) input.y = 0f;
            anim.SetFloat("moveX", input.x);
            anim.SetFloat("moveY", input.y);
        }

        if (hasHorizontalSpeed || hasVerticalSpeed)
        {
            anim.SetBool("isMoving", true);
        }
        else { anim.SetBool("isMoving", false); }
    }
}
