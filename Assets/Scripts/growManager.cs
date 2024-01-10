using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class growManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    public IEnumerator grow(Transform objTransform, GameObject small, GameObject medium, GameObject big)
    {
        Vector3 position = new Vector3(objTransform.position.x, objTransform.position.y, objTransform.position.z);
        GameObject smallTree = Instantiate(small, position, small.transform.rotation);
        yield return new WaitForSeconds(5);
        if (smallTree)
        {
            Destroy(smallTree);
            GameObject mediumTree = Instantiate(medium, position, medium.transform.rotation);
            yield return new WaitForSeconds(5);
            if (mediumTree)
            {
                Destroy(mediumTree);
                GameObject bigTree = Instantiate(big, position, big.transform.rotation);
            }
        }
    }
    
    public void deleteVegetation()
    {
        GameObject[] vegetation = GameObject.FindGameObjectsWithTag("vegetation");
        foreach (GameObject obj in vegetation)
        {
            Destroy(obj);
        }
    }
    
}
