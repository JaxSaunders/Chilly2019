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

    [SerializeField] public Arrow arrow;

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
		print(arrow.transform.eulerAngles.z);
	}

    public IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
		print("Waiting for body to be zero");
		yield return new WaitUntil( () => body.velocity == new Vector2(0, 0) );
        print("now ready to movez");
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
		float angle = arrow.transform.eulerAngles.z;
		Vector3 directionVector = new Vector3(-Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0 );
        body.AddForce(directionVector * thrust);
        thrust = 0.0f;
	}
}
