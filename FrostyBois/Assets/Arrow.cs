using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public SpriteRenderer m_SpriteRenderer;
	[SerializeField] public Player player1;
	[SerializeField] public Player player2;
	// Use this for initialization
	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		m_SpriteRenderer.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
		point();
     }

	void point() 
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Vector2 direction= new Vector2(
			mousePosition.x - transform.position.x,
			mousePosition.y - transform.position.y
		);

		transform.up = direction;
	}
}
