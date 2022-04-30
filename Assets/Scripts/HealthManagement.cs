using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    public void DoDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            if (gameObject.CompareTag("Jonny"))
            {
                GameManager.Instance.Restart();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public int GetCurrentHealth()
    {
        return _health;
    }
}
