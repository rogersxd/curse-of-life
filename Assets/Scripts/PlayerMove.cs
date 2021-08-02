using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedJump = 15.0f;
    public float horizontalInput;
    public float jumpInput;
    private PlayerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        moves();
    }

    void moves() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        if (! playerAnimation.attacking) {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
        

        if (! playerAnimation.attacking && jumpInput > 0) {
            transform.Translate(Vector3.up * (speed * 2) * Time.deltaTime);
        }
    }
}
