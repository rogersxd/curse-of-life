using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSummonAnimation : MonoBehaviour
{
    private GameObject player;
    private PlayerAnimation playerAnimation;
    private Animator animator;
    private bool facingRight;
    private float cooldownAttack = 1f;

    // Start is called before the first frame update
    void Start()
    {
        cooldownAttack += Time.time;

        player = GameObject.FindGameObjectWithTag("Player");

        playerAnimation = player.GetComponent<PlayerAnimation>();

        animator = gameObject.GetComponent<Animator>();

        Vector3 playerPosition = player.transform.position;
        Vector3 enemyPosition = transform.position;
        Vector3 enemyScale = transform.localScale;

        if (playerPosition.x < enemyPosition.x) {
            facingRight = true;
            enemyScale.x  *= -1;
        }

        if (playerPosition.x > enemyPosition.x) {
            facingRight = false;
            enemyScale.x *= 1;
        }

        transform.localScale = enemyScale;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();      

        if (Time.time > cooldownAttack) {
            cooldownAttack += cooldownAttack;
            animator.Play("Attack");
        }
    }

     void Flip()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 enemyPosition = transform.position;
        Vector3 enemyScale = transform.localScale;

        if (playerPosition.x > enemyPosition.x && facingRight) {
            facingRight = !facingRight;
            enemyScale.x  *= -1;
        }

        if (playerPosition.x < enemyPosition.x && !facingRight) {
            facingRight = !facingRight;
            enemyScale.x *= -1;
        }   

        transform.localScale = enemyScale;
    }
}
