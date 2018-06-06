using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour {


	public float Distance = 10;
	bool mouseDown = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			mouseDown = true;
		}

		if (mouseDown) {
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 pos = r.GetPoint (Distance);
			transform.position = pos;
		}

		if (Input.GetMouseButtonUp (0)) {
			mouseDown = false;
		}
	}
}
