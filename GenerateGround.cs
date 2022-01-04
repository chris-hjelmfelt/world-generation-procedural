using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public Transform prefab;

    // Start is called before the first frame update
    void Start()
    {      
        int size = 20;
        for (int i = -size/2; i < size/2; i++)
        {         
            Instantiate(prefab, new Vector3(l * 1F, 0, 0), Quaternion.identity);             
        }
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

}
