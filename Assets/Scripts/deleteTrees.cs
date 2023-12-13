using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deleteTrees : MonoBehaviour
{
    [SerializeField] private Button deleteBtn;

    // Start is called before the first frame update
    void Start()
    {
        deleteBtn.onClick.AddListener(delete);
    }

    void delete()
    {
       GameObject[] trees = GameObject.FindGameObjectsWithTag("tree");

       foreach (GameObject tree in trees)
       {
           Destroy(tree);
       }
    }
}
