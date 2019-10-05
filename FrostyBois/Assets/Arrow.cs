using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	[SerializeField] public Player player1;
	[SerializeField] public Player player2;

	public SpriteRenderer m_SR;

	// Use this for initialization
	void Start () {
		m_SR = GetComponent<SpriteRenderer>();
		m_SR.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
		point();
		fade();
     }

	void point() {
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Vector2 direction= new Vector2(
			mousePosition.x - transform.position.x,
			mousePosition.y - transform.position.y
		);

		transform.up = direction;
	}

	void fade()
	{

        if (player1.active && player1.up && player1.thrusting)
		{
			m_SR.color = Color.Lerp(Color.yellow, Color.red, player1.thrust/player1.maxSpeed);
		}
		else if (player1.active && player1.thrusting)
		{
            m_SR.color = Color.Lerp(Color.red, Color.yellow, (player1.maxSpeed-player1.thrust) / player1.maxSpeed);
		}
        else if (player2.active && player2.up && player2.thrusting)
        {
            m_SR.color = Color.Lerp(Color.yellow, Color.red, player2.thrust / player2.maxSpeed);
        }
        else if (player2.active && player2.thrusting)
        {
            m_SR.color = Color.Lerp(Color.red, Color.yellow, (player2.maxSpeed - player2.thrust) / player2.maxSpeed);
        }
		else
		{
			m_SR.color = Color.yellow;
			m_SR.enabled = false;
		}
        if (player1.active || player2.active)
        {
            m_SR.enabled = true;
        }
	}
}
