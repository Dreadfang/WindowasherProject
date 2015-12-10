using UnityEngine;
using System.Collections;

public class windowHealth : MonoBehaviour
{
	// The amount of health a window has.
	public int health = 3;

	// Used to find script for defeat so i can stop the game.
	public defeat defeatScript;
	void Start()
	{
		// Finds the script for defeat.
		defeatScript = GameObject.FindWithTag("defeatScript").GetComponent<defeat>();
	}

	void Update ()
	{
		//Checks condition of windows and if it is broken changes windowBroken to true in defeat script.
		if (health <= 0)
		{
			Debug.Log ("Window is dead");
			defeatScript.windowBroken = true;
		}

	}

	// Used to check when hit by a bird.
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "bird")
		{
			// Decreases health and removes bird that hit the trigger from game.
			health -= 1;
			Destroy(other.gameObject);
		}
	}
}
