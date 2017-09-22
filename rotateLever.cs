using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLever : MonoBehaviour {

	public GameObject rod;
	public bool left, right, circle;
	public float speed;

	public Camera cam;

	// Use this for initialization
	void Start () {
		if (!circle)
			right = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (left && rod.transform.rotation.x >= -0.06162845)
			rotateLeft ();
		if (right && rod.transform.rotation.x <= 0.06162845)
			rotateRight ();
		if (circle) {
			rotateCircle ();
			speed = 30 + Mathf.Pow(Time.time,5);
		}
	}

	void rotateLeft(){
		rod.transform.Rotate(Vector3.left * Time.deltaTime * speed);
	}
	void rotateRight(){
		rod.transform.Rotate(Vector3.right * Time.deltaTime * speed);
	}

	void rotateCircle(){
		rod.transform.Rotate (Vector3.up * Time.deltaTime * speed);
	}

	public void switchStates(){
		if (!cam.GetComponent<mainScript> ().first) {
			cam.GetComponent<mainScript> ().source3.Play ();
			StartCoroutine (cam.GetComponent<mainScript> ().waitBor ());
		}
		if (right) {
			right = false;
			left = true;
		} else {
			right = true;
			left = false;
		}
		cam.GetComponent<mainScript> ().current [int.Parse (transform.tag) - 1] = true;
	}
}
