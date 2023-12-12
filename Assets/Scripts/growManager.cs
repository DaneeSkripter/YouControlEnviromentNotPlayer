using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class growManager : MonoBehaviour
{
    [SerializeField] private GameObject small;

    [SerializeField] private GameObject medium;

    [SerializeField] private GameObject big;

    [SerializeField] private GameObject spawn;
    [SerializeField] private Button triggerBtn;
    // Start is called before the first frame update
    void Start()
    {
        triggerBtn.onClick.AddListener(startGrowing);
    }

    private void startGrowing()
    {
        StartCoroutine(grow());
    }

    private IEnumerator grow()
    {
        if (!isPositionOccupied(spawn.transform.position))
        {
            GameObject smallTree = Instantiate(small, spawn.transform.position, spawn.transform.rotation);
            yield return new WaitForSeconds(5);
            Destroy(smallTree);
            GameObject mediumTree = Instantiate(medium, spawn.transform.position, spawn.transform.rotation);
            yield return new WaitForSeconds(5);
            Destroy(mediumTree);
            GameObject bigTree = Instantiate(big, spawn.transform.position, spawn.transform.rotation);
        }
        else
        {
            Vector3 newPosition = findFreePosition(spawn.transform.position, 1.0f, 5);
            
            if (newPosition != Vector3.zero)
            {
                GameObject smallTree = Instantiate(small, newPosition, Quaternion.identity);
                yield return new WaitForSeconds(5);
                Destroy(smallTree);
                GameObject mediumTree = Instantiate(medium, newPosition, Quaternion.identity);
                yield return new WaitForSeconds(5);
                Destroy(mediumTree);
                GameObject bigTree = Instantiate(big, newPosition, Quaternion.identity);
            }
        }
    }

    private bool isPositionOccupied(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("tree"))
            {
                return true;
            }
        }

        return false;
    }

    private Vector3 findFreePosition(Vector3 originalPosition, float radius, int maxAttempts)
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Random rnd = new Random();
            float randomX = rnd.Next(-60, 80);
            float randomZ = rnd.Next(15, 145);
            Vector3 newPosition = new Vector3(randomX, -9.6f, randomZ);


            if (!isPositionOccupied(newPosition))
            {
                return newPosition;
            }
        }

        return Vector3.zero;
    }
    
}
