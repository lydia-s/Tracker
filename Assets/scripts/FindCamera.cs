﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        
    }


}
