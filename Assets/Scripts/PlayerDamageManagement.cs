using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageManagement : MonoBehaviour
{
    [SerializeField] private string _deathWallTag;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_deathWallTag))
        {
            GameManager.Instance.Restart();
        }
    }
}
