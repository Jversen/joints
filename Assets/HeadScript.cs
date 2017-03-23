using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour {

	public Rigidbody head;
	public Rigidbody rightFrontThigh;
	public Rigidbody leftFrontThigh;
	public Rigidbody rightBackThigh;
	public Rigidbody leftBackThigh;

	float distToGround;

	int p;
	int k;

	Vector3 bodyPush;
	Vector3 initLegPush;
	Vector3 legPush;
	Vector3 hopp;

	void OnMouseOver(){
		print (gameObject.name);

		if(Input.GetMouseButtonDown(0)){
			gameObject.AddComponent<TriangleExplosion>();
			StartCoroutine(gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));
		}
	}

	// Use this for initialization
	void Start () {
		p = 0;
		k = 1;
		bodyPush = 100 * transform.up;
		initLegPush = 600 * transform.forward + 200*transform.up;
		legPush = 1200 * transform.forward + 200*transform.up;
		//hopp = new Vector3 (0, 5000, 0);
		//distToGround = collider.bounds.extents.y;

		/*gameObject.AddComponent<TriangleExplosion>();
		*TriangleExplosion boom = (TriangleExplosion)gameObject.GetComponent < TriangleExplosion > ();
		*StartCoroutine(.SplitMesh(true));
		*/
	}

	/*bool IsGrounded () {
		return 
	}*/

	// Update is called once per frame
	void Update () {

		//Vector3 dir = other.transform.position - transform.position;
		//dir = other.transform.InverseTransformDirection(dir);
		//float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		//if (Input.GetKeyDown (KeyCode.Space) && IsGrounded ()) {
		if (p >= 100) {
			p = 0;
			head.AddForce (hopp);
				
			if (k == 1){
				leftFrontThigh.AddForce (initLegPush);
				rightBackThigh.AddForce (initLegPush);
				k += 1;
			} 
			else if (k == 2) {
				rightFrontThigh.AddForce (legPush);
				leftBackThigh.AddForce (legPush);
				k += 1;
			}
			else {
				leftFrontThigh.AddForce (legPush);
				rightBackThigh.AddForce (legPush);
				k -= 1;
			}

		} else {
			p += 1;
		}
	//}

		//Konstant lite kraft frammåt
		head.AddForce(bodyPush);

		//float pushHorizontal = Input.GetAxis ("Horizontal");
		//head.AddForce (new Vector3 (0, 0, pushHorizontal * 20));

		//float pushVertical = Input.GetAxis ("Vertical");
		//head.AddForce (new Vector3 (0, pushVertical * 50, 0));
		
	}
}
