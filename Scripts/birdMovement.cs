using UnityEngine;
using System.Collections;

public class birdMovement : MonoBehaviour
{
	// Set speed values from inspector. maxSpeed must be smaller than speed to work properly.
	public float maxSpeed;
	public float speed;
	
	void FixedUpdate()
	{
		// Sets max speed for bird.
		if (GetComponent<Rigidbody2D> ().velocity.magnitude > maxSpeed)
		{
			GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity.normalized * maxSpeed;
		}

		// moves bird.
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-speed, 0));
	}
}
