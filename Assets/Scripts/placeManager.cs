using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeManager : MonoBehaviour
{
    private GameObject currentObject;

    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject medium;
    [SerializeField] private GameObject big;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObject)
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, Mathf.Infinity))
            {
                currentObject.transform.position = new Vector3(hitInfo.point.x, 0f, hitInfo.point.z);
                if (Input.GetMouseButtonDown(0))
                {
                    currentObject.tag = "Untagged";
                    if (isPositionOccupied(currentObject.transform.position) == false)
                    {
                        StartCoroutine(Camera.main.GetComponent<growManager>().grow(currentObject.transform, obj, medium, big));
                        Destroy(currentObject);
                        currentObject = null;
                    }
                }
                else 
                {
                    currentObject.transform.Rotate(Vector3.forward, Input.mouseScrollDelta.y * 10f);   
                }
            }
        }
    }

    private bool isPositionOccupied(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("vegetation"))
            {
                return true;
            }
        }

        return false;
    }
    
    public void enterPlaceMode()
    {
            if (currentObject)
            {
                Destroy(currentObject);
            }
            else
            {
                currentObject = Instantiate(obj);
            }
    }
    
    
}
