using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSounds : MonoBehaviour {

	private Object[] subClips;
	private Object[] borats;
	public Camera cam;
	private bool borat = false;

	private float timeToWait = 30f;

	// Use this for initialization
	void Start () {
		subClips = Resources.LoadAll ("SubwayAnnouncements");
		borats = Resources.LoadAll ("Borat");
		StartCoroutine (makeAnnouncements());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator makeAnnouncements(){
		while (true) {
			yield return new WaitForSeconds (timeToWait);
			if (!borat) {
				AudioClip clip = (AudioClip)subClips [Random.Range (0, subClips.Length)];
				cam.GetComponent<AudioSource> ().clip = clip;
				cam.GetComponent<AudioSource> ().Play ();
			}
			//yield return new WaitForSeconds (timeToWait);
		}

	}

	public void Borat(AudioClip clip){
		StartCoroutine (playBorat (clip));
	}

	IEnumerator playBorat(AudioClip clip){
		cam.GetComponent<AudioSource> ().Stop ();
		borat = true;
		cam.GetComponent<AudioSource> ().clip = clip;
		cam.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(clip.length);
		borat = false;
	}
}
