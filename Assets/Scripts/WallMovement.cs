using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WallMovement : RestartableGameObject
{
    [SerializeField] private float _initialSpeed;
    [SerializeField] private float _initialAcceleration;
    [SerializeField] private float _maxSpeed;

    private float _speed;
    private float _acceleration;
    private Vector3 _initialPosition;
    
    void Start()
    {
        _initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Restart();
    }
    
    // Update is called once per frame
    void Update()
    {
        _speed = _acceleration > 0 ? _speed + _acceleration * Time.deltaTime : _speed;
        transform.position += new Vector3(Mathf.Clamp(_speed * Time.deltaTime, -_maxSpeed, _maxSpeed), 0, 0);
    }

    public override void Restart()
    {
        _speed = _initialSpeed;
        _acceleration = _initialAcceleration;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Jonny"))
        {
            var health = col.gameObject.GetComponent<HealthManagement>();
            health.DoDamage(health.GetCurrentHealth() + 1);
        }
    }
}
