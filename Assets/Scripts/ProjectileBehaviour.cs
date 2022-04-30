using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _timeToLiveInSeconds = 5.0f;
    [SerializeField] private int _damage = 1;
    
    private float _directionMultiplier = 1;

    IEnumerator DestroyInTime(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        
        Destroy(gameObject);
    } 
    
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Jonny");
        if (player == null)
        {
            Debug.LogError("Missing Jonny Tag");
            return;
        }
        if (transform.position.x < player.transform.position.x)
        {
            _directionMultiplier = -1;
            transform.localScale =
                new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        StartCoroutine(DestroyInTime(_timeToLiveInSeconds));
    }

    void Update()
    {
        transform.position += transform.right * (_directionMultiplier * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthManagement enemyHealth = collision.gameObject.GetComponent<HealthManagement>();
            if (enemyHealth != null)
            {
                enemyHealth.DoDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}
