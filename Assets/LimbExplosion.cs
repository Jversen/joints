using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbExplosion : MonoBehaviour {

	void OnMouseOver(){
		print (gameObject.name);

		if(Input.GetMouseButtonDown(0)){
			gameObject.AddComponent<TriangleExplosion>();
			StartCoroutine(gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
