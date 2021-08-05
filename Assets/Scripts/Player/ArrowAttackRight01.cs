using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttackRight01 : MonoBehaviour
{
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        DestroyArrow();
    }

    void DestroyArrow()
    {
        Vector3 position = transform.position;
        
        if (position.x < -150f || position.x > 150f) {
            Destroy(gameObject);
        }
    }
}
