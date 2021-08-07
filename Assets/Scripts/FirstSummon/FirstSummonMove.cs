using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSummonMove : MonoBehaviour
{
    public float speed = 20f;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
