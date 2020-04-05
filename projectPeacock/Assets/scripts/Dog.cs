using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float moveSpeed = 5;
    DogController controller;
    void Start()
    {
        controller = GetComponent<DogController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
