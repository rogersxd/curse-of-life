using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAnimation : MonoBehaviour
{
    private GameObject player;
    private PlayerAnimation playerAnimation;
    private Animator animator;
    private Summon summon;
    private bool facingRight;
    private bool die = false;
    private float cooldownAttack = 1f;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        playerAnimation = player.GetComponent<PlayerAnimation>();
        animator = gameObject.GetComponent<Animator>();
        summon = gameObject.GetComponent<Summon>();

        cooldownAttack += Time.time;

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

        Attack();

        Die();
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

    void Attack()
    {
        if (Time.time > cooldownAttack && !die) {
            cooldownAttack += cooldownAttack;
            animator.Play("Attack");
        }
    }

    void Die()
    {
        if (summon.health <= 0 && !die) {
            die = true;
            animator.Play("Die");
        }
    }
}
