using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommyMovement : MonoBehaviour
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
  
    void Start()
    {  saltos=0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

 
 
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        anim.SetBool("run", Horizontal != 0.0f);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    
        


    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal * Speed, rb.velocity.y);
    }

    private void Jump()
    {  if(saltos<maxSaltos || maxSaltos ==-1){
            if(saltos==0){
                rb.AddForce(Vector2.up * fuerzaSalto);}
            else{
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * fuerzaSalto);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo" || (collision.gameObject.tag == "Suelo2"))
        {
            saltos=0;
            anim.SetBool("estaSaltando", false);
        
        }


    }
}
