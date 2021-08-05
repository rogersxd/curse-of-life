
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float horizontalInput;
    public float jumpInput;
    public bool facingRight;
    private PlayerAttack playerAttack;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = gameObject.GetComponent<PlayerAttack>();
        animator = gameObject.GetComponent<Animator>();
        facingRight = true;   
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        this.Flip(horizontalInput);
        this.Attack();
        this.Move(horizontalInput, jumpInput);
    }

     private void Flip(float horizontalInput) 
    {
        if (horizontalInput > 0 && !facingRight || horizontalInput < 0 && facingRight) {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            return;
        }
    }
    private void Move(float horizontalInput, float jumpInput)
    {
        if (jumpInput > 0) {
            animator.Play("JumpUp");
            return;
        }

        if ((horizontalInput > 0 || horizontalInput < 0) && !playerAttack.attacking) {
            animator.Play("Walk");
            return;
        }
    }

    private void Attack()
    {
        if (Time.time < playerAttack.spawnAttack) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            animator.Play("Attack01");
            return;
        }

        if (playerAttack.topAttacking) {
            animator.Play("Attack02");
            return;
        }

        if (playerAttack.specialAttacking) {
            animator.Play("Attack03");
            return;
        }
    }
}
