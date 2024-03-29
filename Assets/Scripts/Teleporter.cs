﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float limiteX = 9.23f;
    public float limiteY = 5.30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > limiteY)
        {
            transform.position = new Vector3(transform.position.x, -limiteY);           
        }
        if (transform.position.y < -limiteY)
        {
            transform.position = new Vector3(transform.position.x, limiteY);
        }


        if (transform.position.x > limiteX)
        {
            transform.position = new Vector3(-limiteX, transform.position.y);

        }
        if (transform.position.x < -limiteX)
        {
            transform.position = new Vector3(limiteX, transform.position.y);

        }

    }
}
