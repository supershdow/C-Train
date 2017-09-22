using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScript : MonoBehaviour {

	public GameObject[] objs;

	private bool[][] stageMaps;

	public bool[] current;

	public bool first;

	public AudioSource source1;
	public AudioSource source2;
	public AudioSource source3;
	public AudioSource source4;
	public AudioSource source5;
	public AudioSource source6;
	public AudioSource source7;
	public TextMesh text;

	public GameObject parent;
	private int shift = 100;

	private int stage = 0;

	// Use this for initialization
	void Start () {
		first = false;
		current = new bool[6];
		stageMaps = new bool[4][];
		stageMaps[0] = new bool[]{false, false, true, false, false, true};
		stageMaps [1] = new bool[]{ true, true, true, true, true, true };
		stageMaps [2] = new bool[]{ true, false, true, false, true, true };
		stageMaps [3] = new bool[]{ false, true, false, false, true, false };
		/*Debug.Log (source1.clip.name);
		Debug.Log (source2.clip.name);
		Debug.Log (source3.clip.name);
		Debug.Log (source4.clip.name);
		Debug.Log (source5.clip.name);
		Debug.Log (source6.clip.name);
		Debug.Log (source7.clip.name);*/
		source5.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Stage: " + stage;
		if (stage == -1) {
			SceneManager.LoadScene ("Lose");
		} else if (stage == 0) {
			if (wrongPick ()) {
				if (first)
					source7.Play ();
				stage--;
				current = new bool[6];
			}
			if (correct ()) {
				source1.Play ();
				parent.transform.Translate (Vector3.back * shift);
				stage++;
				current = new bool[6];
			}
		} else if (1 <= stage && stage <= 2) {
			if (wrongPick ()) {
				source4.Play ();
				parent.transform.Translate (Vector3.forward * shift);
				stage--;
				current = new bool[6];
			}
			if (correct ()) {
				source1.Play ();
				parent.transform.Translate (Vector3.back * shift);
				stage++;
				current = new bool[6];
			}
		} else if (stage == 3) {
			if (wrongPick ()) {
				source4.Play ();
				parent.transform.Translate (Vector3.forward * shift);
				stage--;
				current = new bool[6];
			}
			if (correct ()) {
				source2.Play ();
				stage++;
				current = new bool[6];
				SceneManager.LoadScene ("Win");
			}
		}

		
	}

	bool wrongPick(){
		for (int i = 0; i < 6; i++)
			if (!stageMaps [stage][i] && current [i])
				return true;
		return false;

	}

	bool correct(){
		for (int i = 0; i < 6; i++)
			if (stageMaps [stage] [i] != current [i])
				return false;
		return true;
	}

	public IEnumerator waitBor(){
		yield return new WaitForSeconds (source4.clip.length);
		first = true;
	}
}
