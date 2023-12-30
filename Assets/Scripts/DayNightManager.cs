using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public float dayLength = 1440f;
    public Light sun;
    public float currentTime = 0f;
    
    void Update()
    {
        updateTime();
        updateSun();
    }

    private int timeSpeed = 0;

    void updateTime()
    {
        currentTime += Time.deltaTime * timeSpeed;
        if (currentTime >= dayLength)
        {
            currentTime = 0f;
        }
    }

    void updateSun()
    {
        float normalizedTime = currentTime / dayLength;

        float angle = Mathf.Lerp(-90f, 270f, normalizedTime);
        sun.transform.eulerAngles = new Vector3(angle, 0f, 0f);
    }

    public void setTimeSpeed(int speed)
    {
        timeSpeed = speed;
    }

    public void setTime(int time)
    {
        currentTime = time;
    }
}
