using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] private float _initialSpeed;
    [SerializeField] private float _initialAcceleration;
    [SerializeField] private float _maxSpeed;

    private float _speed;
    private float _acceleration;

    void Start()
    {
        Restart();
    }
    
    // Update is called once per frame
    void Update()
    {
        _speed = _acceleration > 0 ? _speed + _acceleration * Time.deltaTime : _speed;
        transform.position += new Vector3(Mathf.Clamp(_speed * Time.deltaTime, -_maxSpeed, _maxSpeed), 0, 0);
    }

    public void Restart()
    {
        _speed = _initialSpeed;
        _acceleration = _initialAcceleration;
    }
}
