using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class JonnyMovement : RestartableGameObject
{
    public float fuerzaSalto = 150f;
    public float Speed;
    private Rigidbody2D rb;
    private Animator anim;
    private int saltos;
    public int maxSaltos;
    public float dirX;
    public SpriteRenderer spr;
    private float Horizontal;

    private Vector3 _startPosition;
    
    void Start()
    {  saltos=0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

 
 
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
    
        if (Horizontal < 0.0f && transform.localScale.x >= 0.0f || Horizontal > 0.0f && transform.localScale.x < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }   

        anim.SetBool("run", Horizontal != 0.0f);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    
    
    }
    private void FixedUpdate()
    { 
        float SpeedAux = saltos == 0 ? Speed : Speed-1f;
        rb.velocity = new Vector2(Horizontal * SpeedAux, rb.velocity.y);
    }

    private void Jump()
    {  if(saltos<maxSaltos || maxSaltos ==-1){
            anim.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * fuerzaSalto);
            saltos++;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            saltos=0;
            anim.SetBool("jump", false);
        
        }


    }
    
    public override void Restart()
    {
        transform.position = _startPosition;
        rb.velocity = Vector2.zero;
    }

    public override void UpdateState()
    {
        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
