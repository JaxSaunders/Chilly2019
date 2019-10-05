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

    [SerializeField] public Arrow arrow;

	// Use this for initialization
	void Start () {	
		body = GetComponent<Rigidbody2D>();
		up = true;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
		
		// waits until they stop moving before they can just again.
		print("Waiting for body to be zero");
		yield return new WaitUntil( () => body.velocity == new Vector2(0, 0) );
        print("now ready to movez");

        while (!done)
        {
			// if they press the action key - start incrementing thrust.
			if (Input.GetKey(key))
            {
				print("Updating thrust: " + thrust + " : " + up + " -> " + (thrust + increment) + " : " + (thrust - increment));
				thrust = (up) ? (thrust + increment) : (thrust - increment);

				// if we reach one end, switch up
				if(thrust >= maxSpeed){ up = false;}
				if(thrust <= 0.0f){ up = true; }
			}

			// if they let off the action key - we are done. thrust them in the given direction.
            if (Input.GetKeyUp(key))
            {
                done = true;
				ThrustModel();
            }

			// return nothing while we are still in the loop.
			yield return null;
        }

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
