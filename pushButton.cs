using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushButton : MonoBehaviour {

	public bool push;
	public float speed;
	private bool up;
	public GameObject cyl;
	public Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (push && cyl.transform.localPosition.y >= 0f) {
			cam.GetComponent<mainScript> ().current [int.Parse (transform.tag) - 1] = true;
			buttonDown ();
		} else {
			push = false;
			up = true;
		}
		if (up && cyl.transform.localPosition.y <= .5f) {
			buttonUp ();
		} else {
			up = false;
		}
	}	

	void buttonDown(){
		if (!cam.GetComponent<mainScript> ().first) {
			cam.GetComponent<mainScript> ().source3.Play ();
			StartCoroutine (cam.GetComponent<mainScript> ().waitBor ());
		}
		cyl.transform.Translate (Vector3.down * speed * Time.deltaTime);
	}

	void buttonUp(){
		cyl.transform.Translate (Vector3.up * speed * Time.deltaTime);
	}

	public void startPush(){
		push = true;
	}
}
