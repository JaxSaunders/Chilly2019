using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public float timer;

	private bool waiting;

	private bool p1Active;

	[SerializeField] public Player player1;
    [SerializeField] public Player player2;

	// Use this for initialization
	void Start () {
		player1.Active = true;
		p1Active = true;
		player2.Active = false;
		waiting = false;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!waiting){
			waiting = true;
			if(p1Active){
				print("StartCoroutine(waitForP1());");
				p1Active = false;
                StartCoroutine(waitForP1());
			}
			else{
                print("StartCoroutine(waitForP2());");
                p1Active = true;
                StartCoroutine(waitForP2());
            }
		}
	}

    private IEnumerator waitForP1()
    {
        print("Waiting on player 1");
        yield return StartCoroutine(player1.waitForKeyPress(KeyCode.Space));
        print("Player 1 returned, now for player 2.");
		player2.Active = true;
		waiting = false;

    }

    private IEnumerator waitForP2()
    {
		print("Waiting on player 2");
        yield return StartCoroutine(player2.waitForKeyPress(KeyCode.Space));
        print("Player 2 returned, now for player 1.");
        player1.Active = true;
        waiting = false;

    }
}
