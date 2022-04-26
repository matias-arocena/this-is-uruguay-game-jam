using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement * speed * Time.deltaTime, 0, 0);
       
    }
}
