using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleBehaviour : MonoBehaviour {
    public Rigidbody rightUpperHamstring, rightLowerHamstring;
    public float force;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ContractRightHamstring(force);
    }
    public void ContractRightHamstring(float force)
    {
        Vector3 direction1 = rightUpperHamstring.transform.position - rightLowerHamstring.transform.position;
        direction1.Normalize();
        direction1 = direction1 * force;
        Vector3 direction2 = -direction1;
        rightUpperHamstring.AddForce(direction2*Time.deltaTime);
        rightLowerHamstring.AddForce(direction1*Time.deltaTime);
    }
}
