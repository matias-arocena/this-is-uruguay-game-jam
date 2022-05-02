using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MagoMovement : RestartableGameObject
{
    public int frameinterval;
    
    public Transform Launch;
    public GameObject Projectile;
    public GameObject  Player;
    
    
    void Start()
    {
        StartCoroutine(Shoot());
        
    }

    // Update is called once per frame
   private void Update()
   {
       
       if ((Player.transform.position.x - transform.position.x > 0.0f && transform.localScale.x >= 0.0f) ||
           (Player.transform.position.x - transform.position.x <= 0.0f && transform.localScale.x < 0.0f))
       {
           transform.localScale = new Vector3(-1.0f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
       }

       
   }
   IEnumerator Shoot()
   {
       yield return new WaitForSeconds(2);
        
       Instantiate(Projectile,Launch.position, Launch.rotation);
       StartCoroutine(Shoot());
   }
    
}

