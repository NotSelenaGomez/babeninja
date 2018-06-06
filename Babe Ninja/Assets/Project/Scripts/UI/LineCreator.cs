using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

	int vertexCount = 0;
	bool mouseDown = false;
	LineRenderer line;
	public GameObject blood;
	public GameObject shit;

	void Awake() {
		line = GetComponent<LineRenderer> ();
	}
		

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			mouseDown = true;
		}

		if (mouseDown) {
			line.SetVertexCount (vertexCount + 1);
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			line.SetPosition (vertexCount, mousePos);
			vertexCount++;


			BoxCollider2D box = gameObject.AddComponent<BoxCollider2D> ();
			box.transform.position = line.transform.position;
			box.size = new Vector2 (0.12f, 0.2f);
		}

		if (Input.GetMouseButtonUp (0)) {
			mouseDown = false;
			vertexCount = 0;
			line.SetVertexCount (0);

			BoxCollider2D[] colliders = GetComponents<BoxCollider2D> ();

			foreach (BoxCollider2D box in colliders) {
				
				Destroy (box);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Head") {

			GameObject f = Instantiate (blood, col.transform.position, Quaternion.identity);
			Destroy (f.gameObject, 0.5f); 

		}

		if (col.gameObject.tag == "Evan") {

			GameObject b = Instantiate (shit, col.transform.position, Quaternion.identity);
			Destroy (b.gameObject, 1.5f); 
		}

	}
}
