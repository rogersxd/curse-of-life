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
        spawnAttack = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.MainAttack();
    }

    void MainAttack()
    {
        if (Time.time < spawnAttack || playerAnimation.jumpInput > 0) {
            return;
        }

        if (Time.time > spawnAttack) {
            mainAttacking = false;
            topAttacking = false;
            specialAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            attacking = true;
            mainAttacking = true;
            
            Invoke("DispatchOneArrow", .3f);
            
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
        }
    }

    void DispatchOneArrow()
    {
        if (playerAnimation.facingRight) {
            Instantiate(
                arrowRightPreFab,
                new Vector3(gameObject.transform.position.x + 3f, gameObject.transform.position.y, gameObject.transform.position.z), 
                Quaternion.identity
            );
            UpdateSpawnAttack();

            return;
        }

        Instantiate(
            arrowLeftPreFab,
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), 
            Quaternion.identity
        );
        UpdateSpawnAttack();
    }

    void UpdateSpawnAttack()
    {
        spawnAttack += 2f;
    }
}
