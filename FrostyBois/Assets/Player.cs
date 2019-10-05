using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float thrust;
	public bool up;
	public bool active;
	public bool thrusting;

    [SerializeField] public float maxSpeed;
	[SerializeField] public Rigidbody2D body;
	[SerializeField] public float increment;

    [SerializeField] public Arrow arrow;

	// Use this for initialization
	void Start () {	
		body = GetComponent<Rigidbody2D>();
		up = true;
		thrusting = false;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;

		// waits until they stop moving before they can just again.
		print("Waiting for body to be zero");
		yield return new WaitUntil( waitConditions() );
        print("now ready to movez");
		active = true;
        while (!done)
        {
			// if they press the action key - start incrementing thrust.
			if (Input.GetKey(key))
            {
				print("PRessing");
				thrusting = true;
				//print("Updating thrust: " + thrust + " : " + up + " -> " + (thrust + increment) + " : " + (thrust - increment));
				thrust = (up) ? (thrust + increment) : (thrust - increment);

				// if we reach one end, switch up
				if(thrust >= maxSpeed){ up = false;}
				if(thrust <= 0.0f){ up = true; }
			}

			// if they let off the action key - we are done. thrust them in the given direction.
            if (Input.GetKeyUp(key))
            {
                active = false;
                done = true;
				ThrustModel();
				thrusting = false;
            }


			// return nothing while we are still in the loop.
			yield return null;
        }

    }

	System.Func<bool> waitConditions(){
		System.Func<bool> test = () => {
			return body.velocity == new Vector2(0, 0);
		};
		return test;
	}

	public void ThrustModel(){
		// gets the direction of where your mouse is pointing
		float angle = arrow.transform.eulerAngles.z;
		Vector3 directionVector = new Vector3(-Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0.00f );
		print("Angle is: " + angle);
	
		// adds thrust for the jump.
		thrust += 100.0f;
        print("Final thrust " + thrust);
        body.AddForce(directionVector * thrust);

		// resets thrust.
        thrust = 0.0f;
	}
}
