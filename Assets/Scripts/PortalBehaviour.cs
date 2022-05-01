using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] _deactivateEntities;
    [SerializeField] private GameObject[] _activateEntities;
    [SerializeField] private Camera _currentCamera;
    [SerializeField] private Camera _nextCamera;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Jonny") || col.gameObject.CompareTag("Player"))
        {
            foreach (var obj in _deactivateEntities)
            {
                obj.SetActive(false);
            }

            foreach (var obj in _activateEntities)
            {
                obj.SetActive(true);
            }

            _currentCamera.enabled = false;
            _nextCamera.enabled = true;
        }
    }
}
