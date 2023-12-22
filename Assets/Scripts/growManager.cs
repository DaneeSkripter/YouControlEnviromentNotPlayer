using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Vector3 position = new Vector3();
        if (!isPositionOccupied(spawn.transform.position))
        {
            position = spawn.transform.position;
        }
        else
        {
            Vector3 newPosition = findFreePosition(spawn.transform.position, 1.2f, 5);
            if (newPosition != Vector3.zero)
            {
                position = newPosition;
            }
        }
        GameObject smallTree = Instantiate(small, position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        if (smallTree)
        {
            Destroy(smallTree);
            GameObject mediumTree = Instantiate(medium, position, Quaternion.identity);
            yield return new WaitForSeconds(5);
            if (mediumTree)
            {
                Destroy(mediumTree);
                GameObject bigTree = Instantiate(big, position, Quaternion.identity);
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
            Vector3 newPosition = new Vector3(randomX, -8.6f, randomZ);


            if (!isPositionOccupied(newPosition))
            {
                return newPosition;
            }
        }

        return Vector3.zero;
    }
    
}
