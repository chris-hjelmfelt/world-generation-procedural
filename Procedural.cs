using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public Transform prefab;
    private int chunkSize = 90;
    private int mainSurface = 35;
    private float frequency = 0.1f;
    private float amplitude = 6.0f;
	
    void Start()
    {        
        for (int l = 0; l < chunkSize; l++)
        {
          var x = l * 4;
          for (int w = 0; w < chunkSize; w++)
          {         	           
            
            var surface = mainSurface + Mathf.Sin((float)x * frequency) * amplitude;                   
            //Debug.Log(surface);

            for (int h = 0; h < chunkSize; h++)
            {     
              if (h < surface){
                Instantiate(prefab, new Vector3(l * 1F, h * 1F, w * 1F), Quaternion.identity);
              }
            }
          }
        }
    }	
}
