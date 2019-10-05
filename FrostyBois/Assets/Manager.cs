using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
	private bool waiting;
	public int currentTurn;
	public int numOfPlayers;
	public List<Player> listOfPlayers = new List<Player>();

	[SerializeField] public Player player1;
    [SerializeField] public Player player2;
	[SerializeField] public Arrow arrow;

	// Use this for initialization
	void Start () {
		waiting = false;
		currentTurn = 0;

		listOfPlayers.Add(player1);
		listOfPlayers.Add(player2);
		numOfPlayers = 2;
	}
	
	// Update is called once per frame
	void Update () {
		// if im currently not waiting on any character
		if(!waiting){
			
			// start waiting on the next character in the list
			waiting = true;

			// the next character is the next person in the list. once we reach the end it loops back around to the beginning.
            print("Starting routine for player: " + ( (currentTurn % numOfPlayers) + 1 ) );
            StartCoroutine( waitForPN(currentTurn % numOfPlayers) );

			// increment the turn counter
			currentTurn++;
		}
		if (((currentTurn % numOfPlayers) + 1) == 2)
		{
			arrow.transform.position = player1.transform.position;
			//arrow.transform.position.y = player1.transform.position.y;
			//arrow.transform.position.z = player1.transform.position.z;
		}
		else
		{
			arrow.transform.position = player2.transform.position;
			//arrow.transform.position.y = player2.transform.position.y;
			//arrow.transform.position.z = player2.transform.position.z;
		}

	}

    private IEnumerator waitForPN(int index)
    {
        print("Waiting on player: " + (index + 1) );
        yield return StartCoroutine(listOfPlayers[index].waitForKeyPress(KeyCode.Mouse0));
        print("Player returned, now for next player.");
        waiting = false;
    }
}
