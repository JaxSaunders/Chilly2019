using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		point();
     }

	void point() {
		Vector3 mousePosition = Input.mousePosition;
		print(mousePosition.x);
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Vector2 direction= new Vector2(
			mousePosition.x - transform.position.x,
			mousePosition.y - transform.position.y
		);

		transform.up = direction;
	}
}
