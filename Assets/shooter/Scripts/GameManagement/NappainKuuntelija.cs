using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NappainKuuntelija : MonoBehaviour {

    public SceneChanger SceneChanger;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneChanger.LoadScene();
        }
    }

   
}
