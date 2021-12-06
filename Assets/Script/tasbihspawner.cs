using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasbihspawner : MonoBehaviour
{
    public GameObject tasbih;
    public float SpawnRate = 0f;
    public float NextSpawn = 0f;

    private float[] linepos = {-0.75f, 1.33f};
    float randomX;
    float x=2f;
    int randomY;
    Vector2 whereToSpawn;


    // Update is called once per frame
    void Update()
    {
      if (Time.time > NextSpawn){
         
          
          randomX = Random.Range(-1f, 20f);
          randomY = Random.Range(0, linepos.Length);
          whereToSpawn = new Vector2(x, linepos[randomY]);
          Instantiate (tasbih, whereToSpawn, Quaternion.identity);
          x += 30f;

          NextSpawn = Time.time + SpawnRate;
        //   Debug.log(Time.time + SpawnRate); 
      }  
    }
}
