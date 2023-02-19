using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
	public Transform prefab;
	public int chunkSize = 20;
	
    // Start is called before the first frame update
    void Start()
    {        
        for (int h = 0; h < chunkSize; h++)
        {
          for (int w = 0; w < chunkSize; w++)
          {
            for (int l = 0; l < chunkSize; l++)
            {
				var rnd = Random.Range(0, 2);	
				Debug.Log(rnd);
				if (rnd == 1){
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
