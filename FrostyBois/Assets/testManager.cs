using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testManager : MonoBehaviour {

	private List<Player> playerList = new List<Player>();
	private Vector3 runningPosition = new Vector3(+50,0);
	[SerializeField] public GameObject master;
	private int playerCount;

	// Use this for initialization
	void Start () {
		playerCount = 0;
		playerList.Add(spawnPlayer());
	}
	
	// Update is called once per frame
	void Update () {

	}

	private Player spawnPlayer(){
		Player clone = new Player();
		Instantiate(master);
		print("I am spawned");
		return clone;
	}
}
