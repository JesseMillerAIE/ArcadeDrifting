using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    int xCount = 20;
    int yCount = 20;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < xCount; i++)
        {
            for (int k = 0; k < yCount; k++)
            {
                Instantiate(prefab, new Vector3(i, 0.5f, k), Quaternion.identity);  
            }
        }
    }
}
