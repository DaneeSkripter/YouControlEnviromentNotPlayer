using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weatherManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem rain;
    [SerializeField] private ParticleSystem snow;

// Start is called before the first frame update

    void Start()
    {
        if (rain.isPlaying)
        {
            rain.Stop();
        }

        if (snow.isPlaying)
        {
            snow.Stop();
        }
    }

public void startStopRain()
    {
        if (rain.isPlaying)
        {
            rain.Stop();
        }
        else
        {
            rain.Play();
        }
    }

public void startStopSnow()
{
    if (snow.isPlaying)
    {
        snow.Stop();
    }
    else
    {
        snow.Play();
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
