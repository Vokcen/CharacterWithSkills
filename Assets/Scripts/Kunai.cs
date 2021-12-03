using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
 [SerializeField] float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Rotate(0,1*speed,0);
        
    }
}
