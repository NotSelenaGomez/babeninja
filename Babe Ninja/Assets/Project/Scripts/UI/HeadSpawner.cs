using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSpawner : MonoBehaviour {

	public GameObject head;
	public GameObject ransom;
	public float maxX;

	// Use this for initialization
	void Start () {
		Invoke ("StartSpawning", 1f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSpawning(){
		InvokeRepeating ("SpawnHeadGroups", 1, 2.5f);
	}

	public void StopSpawning(){
		CancelInvoke ("SpawnHeadGroups");
		StopCoroutine ("SpawnHead");
	}

	public void SpawnHeadGroups(){

		StartCoroutine ("SpawnHead");

		if (Random.Range (0, 6) > 4) {
			SpawnRansom ();
		}
	}

	IEnumerator SpawnHead(){

		for (int i = 0; i < 1; i++) {

			float Rand = Random.Range (-maxX, maxX);
			Vector3 pos = new Vector3 (Rand, transform.position.y, 0);
			GameObject f = Instantiate (head, pos, Quaternion.identity) as GameObject;
			f.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 13f), ForceMode2D.Impulse);
			f.GetComponent<Rigidbody2D> ().AddTorque (Random.Range(-7f,7f));
			yield return new WaitForSeconds (0.2f);
		
		}

	}

	void SpawnRansom(){

		float Rand = Random.Range (-maxX, maxX);
		Vector3 pos = new Vector3 (Rand, transform.position.y, 0);
		GameObject b = Instantiate (ransom, pos, Quaternion.identity) as GameObject;
		b.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 13f), ForceMode2D.Impulse);
		b.GetComponent<Rigidbody2D> ().AddTorque (Random.Range(-7f,7f));

	}
}
