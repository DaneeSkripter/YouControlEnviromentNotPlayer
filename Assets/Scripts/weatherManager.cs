using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weatherManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem rain;

// Start is called before the first frame update

    void Start()
    {
        if (rain.isPlaying)
        {
            rain.Stop();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
