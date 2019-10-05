using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float thrust;
	public bool up;
	[SerializeField] public float maxSpeed;
	[SerializeField] public Rigidbody2D body;
	[SerializeField] public float increment;
	// Use this for initialization
	void Start () {
		up = true;	
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (body.velocity == new Vector2(0,0))
		{
			if (Input.GetKey(KeyCode.Space))
			{
				if (up)
				{
					thrust+= increment;
					if (thrust >= maxSpeed)
					{
						up = false;
					}
				}
				else
				{
					thrust-= increment;
					if (thrust <= 0.0f)
					{
						up = true;
					}
				}		
			}
			if (Input.GetKeyUp(KeyCode.Space))
			{
				thrust += 100.0f;
				print("Final thrust " + thrust);
				body.AddForce(new Vector3(1, 1, 0) * thrust);
				thrust = 0.0f;
			}
		}
	}
}
