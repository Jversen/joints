using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LegScript : MonoBehaviour {


	public Rigidbody head;
	public Rigidbody thigh;
	public Rigidbody knee;
	public Rigidbody shin;
	public Rigidbody ankle;
	public Rigidbody toe;

	public Transform parentObject;
	private float parentRotX;
	private float parentRotY;
	private float parentRotZ;

	private Vector3 vectorX;
	private Vector3 vectorY;
	private Vector3 vectorZ;

	private float g;
	private float m1;
	private float m2;
	private float m3;

	// Use this for initialization
	void Start () {
		vectorX = new Vector3 (1, 0, 0);
		vectorY = new Vector3 (0, 1, 0);
		vectorZ = new Vector3 (0, 0, 1);

		parentRotX = parentObject.rotation.eulerAngles.x;
		parentRotY = parentObject.rotation.eulerAngles.y;
		parentRotZ = parentObject.rotation.eulerAngles.z;
		g = Physics.gravity.y;
		m1 = head.mass;
		m2 = head.mass + thigh.mass;
		m3 = head.mass + thigh.mass + shin.mass;

		print ("parentRotX: " + parentRotX + ", parentRotY: " + parentRotY + ", parentRotZ: " + parentRotZ );
		
	}
	
	// Update is called once per frame
	void Update () {
		float thighRotX = thigh.rotation.eulerAngles.x - parentRotX;
		float thighRotY = thigh.rotation.eulerAngles.y - parentRotY;
		float thighRotZ = thigh.rotation.eulerAngles.z - parentRotZ;

		float shinRotX = shin.rotation.eulerAngles.x - parentRotX;
		float shinRotY = shin.rotation.eulerAngles.y - parentRotY;
		float shinRotZ = shin.rotation.eulerAngles.z - parentRotZ;

		if (shinRotX > 180) {
			shinRotX = shinRotX - 360;
		}
		double alphaInRadians = Math.PI * (thighRotX / 180.0);
		float cosAlpha = (float) Math.Sin (alphaInRadians);
		float kneeForce = m1 * g * cosAlpha;


		if (thighRotX > 180) {
			thighRotX = shinRotX - 360;
		}
		double betaInRadians = Math.PI * (shinRotX / 180.0);
		float cosBeta = (float) Math.Sin (betaInRadians);
		float ankleForce = m2 * g * cosBeta;

		//double gammaInRadians = Math.PI * (shinRotX / 180.0);
		//float cosGamma = (float) Math.Sin (gammaInRadians);
		float toeForce = 0.001f;//* m3 * g;

		print ("kneeForce = " + kneeForce + ", ankleForce = " + ankleForce + ", toeForce = " + toeForce);


		knee.AddRelativeForce (new Vector3 (0, 0, kneeForce));
		ankle.AddRelativeForce (new Vector3 (0, 0, -ankleForce));
		toe.AddRelativeForce(new Vector3 (0, toeForce, 0));


		//ankle.AddRelativeForce (new Vector3 (0, 0, 100));


		/*
		//float intensity = Input.GetAxis("Vertical");
		//thisFoot.AddTorque (vector * tq * intensity);
		float shinRotX = shin.rotation.x; //.eulerAngles[0]/360;
		float shinRotY = shin.rotation.y; //.eulerAngles[1]/360;
		float shinRotZ = shin.rotation.z; //.eulerAngles[2]/360;

		//print (name);
		if (name == ("RightBackFoot (3)")){
			print("headless shinRotX = " + shinRotX);
			print("headless shinRotY = " + shinRotY);
			print("headless shinRotZ = " + shinRotZ);
		}
		int limitAngle = 15;
		float rotConst = 100f;

		if (shinRotX < (-limitAngle)) {
			if (name == ("RightBackFoot (3)")){
				print("headless X thisFoot.AddTorque " + (-(rotConst *  vectorX * tq)));
			}
			thisFoot.AddTorque (-(rotConst *  vectorX * tq), ForceMode.Impulse);
		} else if (shinRotX > limitAngle) {
			if (name == ("RightBackFoot (3)")){
				print("headless X thisFoot.AddTorque " + ((rotConst *  vectorX * tq)));
			}
			thisFoot.AddTorque (-(rotConst *  vectorX * tq), ForceMode.Impulse);

		}

		//		if (shinRotY < (-limitAngle)) {
		//			thisFoot.AddTorque (rotConst * shinRotY * vector * tq);
		//		} else if (shinRotY > limitAngle) {
		//			thisFoot.AddTorque (-(rotConst * shinRotY * vector * tq));
		//		}

		if (shinRotZ < (-limitAngle)) {
			if (name == ("RightBackFoot (3)")){
				print("headless Z thisFoot.AddTorque " + (-(rotConst *  vectorZ * tq)));
			}
			thisFoot.AddTorque (-(rotConst *  vectorZ * tq), ForceMode.Impulse);
		} else if (shinRotZ > limitAngle) {
			if (name == ("RightBackFoot (3)")){
				print("headless Z thisFoot.AddTorque " + (-(rotConst *  vectorZ * tq)));
			}
			thisFoot.AddTorque (-(rotConst *  vectorZ * tq), ForceMode.Impulse);
		}
		*/
	}
}
