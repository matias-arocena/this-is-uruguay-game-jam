using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using DefaultNamespace;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

enum FollowState
{
    Following,
    Patrolling
}

public class FollowingBehaviour : RestartableGameObject
{
    [SerializeField] private float _patrollingRange = 2.0f;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _visionRange = 2.0f;

    private GameObject _jonny;
    private FollowState _state = FollowState.Patrolling;
    private Vector3 _patrollingObjective;

    private Vector3 _startPosition;
    private float _startPatrollingRange;
    
    // Start is called before the first frame update
    void Start()
    {
        _jonny = GameObject.FindGameObjectWithTag("Jonny");
        if (_jonny == null)
        {
            Debug.LogError("No existe ningun GameObject con tag Jonny");
        }

        _patrollingObjective = new Vector3(transform.position.x + _patrollingRange, transform.position.y,
            transform.position.z);
        _patrollingRange *= -1;

        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _startPatrollingRange = _patrollingRange;
    }

    // Update is called once per frame
    void Update()
    {
        if ((_jonny.transform.position - transform.position).magnitude > _visionRange)
        {
            _state = FollowState.Patrolling;
        }
        else
        {
            _state = FollowState.Following;
        }
        switch (_state)
        {
            case FollowState.Following:
                transform.position +=
                    (_jonny.transform.position - transform.position).normalized * 
                    (_speed * Time.deltaTime);
                if ((_jonny.transform.position.x - transform.position.x > 0.0f && transform.localScale.x >= 0.0f) ||
                    (_jonny.transform.position.x - transform.position.x <= 0.0f && transform.localScale.x < 0.0f))
                {
                    transform.localScale = new Vector3(-1.0f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
                } 
                break;
            case FollowState.Patrolling:
                transform.position += 
                    (_patrollingObjective - transform.position).normalized *
                    (_speed * Time.deltaTime);
                if ((_patrollingObjective - transform.position).sqrMagnitude < Vector3.kEpsilon)
                {
                    _patrollingObjective = new Vector3(_patrollingObjective.x + _patrollingRange,
                        _patrollingObjective.y, _patrollingObjective.z);
                    _patrollingRange *= -1;
                }
                
                if ((_patrollingObjective.x - transform.position.x > 0.0f && transform.localScale.x >= 0.0f) ||
                    (_patrollingObjective.x - transform.position.x <= 0.0f && transform.localScale.x < 0.0f))
                {
                    transform.localScale = new Vector3(-1.0f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Jonny"))
        {
            var health = col.gameObject.GetComponent<HealthManagement>();
            health.DoDamage(health.GetCurrentHealth() + 1);
        }
    }

    public override void Restart()
    {
        transform.position = _startPosition;
        _patrollingObjective = new Vector3(transform.position.x + _startPatrollingRange, transform.position.y,
            transform.position.z);
        _patrollingRange = -_startPatrollingRange;
    }
}
