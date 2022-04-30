using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SetMeOnFireBehaviour : MonoBehaviour
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
        _fireParticles.Stop(true);
        GameManager.Instance.Restart();
    }
}
