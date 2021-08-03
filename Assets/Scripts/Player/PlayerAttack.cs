using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrowRightPreFab;
    public GameObject arrowLeftPreFab;
    public GameObject arrowPreFab;
    public bool attacking = false;
    public bool mainAttacking = false;
    public bool topAttacking = false;
    public bool specialAttacking = false;
    public float spawnAttack;

    PlayerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = gameObject.GetComponent<PlayerAnimation>();
        spawnAttack = Time.time + 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SpawnAttack");
        this.MainAttack();
    }

    void MainAttack()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            attacking = true;
            mainAttacking = true;
            return;
        }

        if (Input.GetKey(KeyCode.P)) {
            attacking = true;
            topAttacking = true;
            return;
        }

        if (Input.GetKey(KeyCode.O)) {
            attacking = true;
            specialAttacking = true;
            return;
        }

        if (Input.GetKeyUp(KeyCode.Return)) {
            attacking = false;
            mainAttacking = false;
            topAttacking = false;
            specialAttacking = false;
        }
    }

    void DispatchOneArrow()
    {
        if (Time.time < spawnAttack) {
            return;
        }

        if (playerAnimation.facingRight) {
            Instantiate(
                arrowRightPreFab,
                new Vector3(gameObject.transform.position.x + 3f, gameObject.transform.position.y, gameObject.transform.position.z), 
                Quaternion.identity
            );
            spawnAttack += 1.2f;

            return;
        }

        Instantiate(
            arrowLeftPreFab,
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), 
            Quaternion.identity
        );
        spawnAttack += 1.2f;
    }

    IEnumerator SpawnAttack()
    {
        while(attacking) {
            yield return new WaitForSeconds(.1f);
            DispatchOneArrow();
        }
    }
}
