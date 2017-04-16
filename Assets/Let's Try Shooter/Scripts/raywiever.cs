using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raywiever : MonoBehaviour {

    public float WeaponRange = 50f;

    private Camera fpscam; 

	// Use this for initialization
	void Start ()
    {
        fpscam = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 lineOrigin = fpscam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, fpscam.transform.forward * WeaponRange, Color.green);

	}
}
