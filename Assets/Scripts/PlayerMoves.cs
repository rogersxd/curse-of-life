using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedJump = 15.0f;
    public float horizontalInput;
    public float jumpInput;

    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        moves();
    }

    void moves() {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        if (jumpInput > 0) {
            transform.Translate(Vector3.up * (speed * 2) * Time.deltaTime);
        }

        this.flip(horizontalInput);
    }

    private void flip(float horizontalInput) {
        
        if (horizontalInput > 0 && !facingRight || horizontalInput < 0 && facingRight) {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            return;
        }
    }
}
