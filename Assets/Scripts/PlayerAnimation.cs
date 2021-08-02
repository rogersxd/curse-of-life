
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float horizontalInput;
    public float jumpInput;
    private bool facingRight;
    public bool attacking = false;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        facingRight = true;   
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        this.flip(horizontalInput);
        this.mainAttack();
        this.move(horizontalInput, jumpInput);
        
    }

     private void flip(float horizontalInput) 
    {
        if (horizontalInput > 0 && !facingRight || horizontalInput < 0 && facingRight) {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            return;
        }
    }
    private void move(float horizontalInput, float jumpInput)
    {
        if (jumpInput > 0) {
            animator.Play("JumpUp");
            return;
        }

        if ((horizontalInput > 0 || horizontalInput < 0) && !attacking) {
            animator.Play("Walk");
            return;
        }
    }

    private void mainAttack()
    {
        if (Input.GetKey(KeyCode.Return)) {
            attacking = true;
            animator.Play("Attack01");
            return;
        }

        if (Input.GetKey(KeyCode.P)) {
            attacking = true;
            animator.Play("Attack02");
            return;
        }

        if (Input.GetKey(KeyCode.O)) {
            attacking = true;
            animator.Play("Attack03");
            return;
        }

        attacking = false;
    }
}
