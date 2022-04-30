using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShitOnFireBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var fire = other.gameObject.GetComponent<SetMeOnFireBehaviour>();
        if (fire == null) return;
        fire.SetOnFire();
    }
}