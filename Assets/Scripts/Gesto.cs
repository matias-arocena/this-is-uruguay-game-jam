using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gesto : MonoBehaviour
{ private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void  OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "mesa" )
        {
            anim.SetBool("esclamar", false);
        
        }
   
      
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "mesa" )
        {
            anim.SetBool("esclamar", true);
        
        }
    }
}
