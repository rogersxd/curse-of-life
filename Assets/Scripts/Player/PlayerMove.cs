using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;
    public float speedJump = 30.0f;
    public float horizontalInput;
    public float jumpInput;
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        if (! playerAttack.attacking) {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
        

        if (! playerAttack.attacking && jumpInput > 0) {
            transform.Translate(Vector3.up * (speed * 2) * Time.deltaTime);
        }
    }
}
