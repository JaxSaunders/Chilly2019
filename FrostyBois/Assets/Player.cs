using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float thrust;
	public bool up;
	public bool Active;

	public int counter;

    [SerializeField] public int playerID;
    [SerializeField] public float maxSpeed;
	[SerializeField] public Rigidbody2D body;
	[SerializeField] public float increment;
	public bool toggle;
	// Use this for initialization
	void Start () {	
		body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Active)
		{
			Active = false;
			StartCoroutine(waitForKeyPress(KeyCode.Space));
		}
	}

    public IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            thrust = (up) ? (thrust + increment) : (thrust - increment);

			// if we reach one end, switch up
			if(thrust >= maxSpeed){ up = false;}
			if(thrust <= 0.0f){up = true;}

            if (Input.GetKeyUp(key))
            {
                done = true; // breaks the loop
				ThrustModel();
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }

    }

	public void ThrustModel(){
        thrust += 100.0f;
        print("Final thrust " + thrust);
        body.AddForce(new Vector3(1, 1, 0) * thrust);
        thrust = 0.0f;
	}
}
