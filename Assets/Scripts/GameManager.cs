using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private RestartableGameObject[] _objectsAhead;
    
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
   }

    public void Start()
    {
        _objectsAhead = FindObjectsOfType<RestartableGameObject>();
    }

    public void Restart()
    {
        foreach (var obj in _objectsAhead)
        {
            obj.Restart();
        }
    }

    public void Unregister(RestartableGameObject obj)
    {
        _objectsAhead = _objectsAhead.Where(v => v != obj).ToArray();
    }
}
