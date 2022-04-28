using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaivour : MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _timeToLiveInSeconds = 5.0f;

    private float _directionMultiplier = 1;

    IEnumerator DestroyInTime(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        
        Destroy(gameObject);
    } 
    
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Jonny");
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
        transform.position += _directionMultiplier * transform.right * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
