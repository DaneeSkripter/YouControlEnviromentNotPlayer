using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            other.gameObject.transform.position = new Vector3(50.51f, 8.3f, 74.57f);
        }
    }
}
