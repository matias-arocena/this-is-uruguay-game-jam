using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DefaultNamespace;
using UnityEngine;

public class SetMeOnFireBehaviour : RestartableGameObject
{
    [SerializeField] private float _secondsToRestart = 1.0f;
    [SerializeField] private ParticleSystem _fireParticles;

    private void Start()
    {
        _fireParticles.Stop(true);
    }

    public void SetOnFire()
    {
        _fireParticles.Play(true);
        StartCoroutine("RestartInTime");
    }

    IEnumerator RestartInTime()
    {
        yield return new WaitForSeconds(_secondsToRestart);
        GameManager.Instance.Restart();
    }

    public override void Restart()
    {
        _fireParticles.Stop(true);
        _fireParticles.GetComponent<Renderer>().enabled = false;
    }
}
