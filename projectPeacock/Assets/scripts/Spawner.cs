using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Duck duck;


    void Start()
    {

       
        Duck spawnedDuck = Instantiate(duck, new Vector3(0,.2f,-20), Quaternion.identity) as Duck;
        Instantiate(duck, new Vector3(5, .2f, -10), Quaternion.identity);

    }

  
    void Update()
    {
        
    }
}
