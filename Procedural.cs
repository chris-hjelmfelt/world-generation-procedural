using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
	public Transform prefab;
	private int chunkSize = 40;
  private int mainSurface = 10;
  private float frequency = 0.2f;
  private float amplitude = 4.0f;
	
    void Start()
    {        
        for (int l = 0; l < chunkSize; l++)
        {
          for (int w = 0; w < chunkSize; w++)
          {
            var rndBlock = Random.Range(0, 2);	
            Debug.Log(rndBlock);
            var x = l * 18;
            var surface = mainSurface + Mathf.Sin((float)x + frequency) * amplitude;

            for (int h = 0; h < chunkSize; h++)
            {              
              if (h < surface){
                Instantiate(prefab, new Vector3(l * 1F, h * 1F, w * 1F), Quaternion.identity);
              }
            }
          }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
}
