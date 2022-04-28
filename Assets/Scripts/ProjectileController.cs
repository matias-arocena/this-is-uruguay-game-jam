using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private ProjectileBehaivour _projectile;
    [SerializeField] private Transform _launchOffset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Instantiate(_projectile, _launchOffset.position, _launchOffset.rotation);
        }
        
    }
}
