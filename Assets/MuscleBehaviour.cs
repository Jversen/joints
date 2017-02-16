﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleBehaviour : MonoBehaviour {
    public Rigidbody rightFrontUpperHamstring, rightFrontLowerHamstring;
    public float force;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ExtendRightFrontHamstring(force);
    }
    public void ContractRightFrontHamstring(float force)
    {
        Vector3 direction1 = rightFrontUpperHamstring.transform.position - rightFrontLowerHamstring.transform.position;
        direction1.Normalize();
        direction1 = direction1 * force;
        Vector3 direction2 = -direction1;
        rightFrontUpperHamstring.AddForce(direction2*Time.deltaTime);
        rightFrontLowerHamstring.AddForce(direction1*Time.deltaTime);
    }
    public void ExtendRightFrontHamstring(float force)
    {
        Vector3 direction1 = rightFrontUpperHamstring.transform.position - rightFrontLowerHamstring.transform.position;
        direction1.Normalize();
        direction1 = direction1 * force;
        Vector3 direction2 = -direction1;
        rightFrontUpperHamstring.AddForce(direction1 * Time.deltaTime);
        rightFrontLowerHamstring.AddForce(direction2 * Time.deltaTime);
    }
}