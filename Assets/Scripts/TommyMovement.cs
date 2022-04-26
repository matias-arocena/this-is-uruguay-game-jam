using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommyMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    bool jump;
   
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }


        Animator.SetBool("Running", Horizontal != 0.0f);

        if (Horizontal < 0.0f && transform.localScale.x >= 0.0f || Horizontal > 0.0f && transform.localScale.x < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }   

    }
    private void Jump()
    {
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
            Animator.SetBool("Jumping", jump);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }
}
