using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor.UIElements;
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
                var restartableGameObject = gameObject.GetComponents<RestartableGameObject>();
                foreach (var obj in restartableGameObject)
                {
                    GameManager.Instance.Unregister(obj);
                }
            }
        }
    }

    public int GetCurrentHealth()
    {
        return _health;
    }
}
