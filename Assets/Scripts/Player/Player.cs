using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = 100;
    public int mainDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemySummon") {
            DamageSummon(collision);
        }
    }

    void DamageSummon(Collision2D collision)
    {
        Summon summon = collision.gameObject.GetComponent<Summon>();
        health -= summon.damage;
    }
}
