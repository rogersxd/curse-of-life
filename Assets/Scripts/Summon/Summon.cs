using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public int damage = 5;
    public int health = 30;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "MainArrow") {
            Damage(collision);
        }
    }

    void Damage(Collision2D collision)
    {
        health -= player.mainDamage;

        if (health <= 0) {
            Invoke("Die", .2f);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
