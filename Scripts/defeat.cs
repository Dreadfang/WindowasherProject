using UnityEngine;
using System.Collections;

public class defeat : MonoBehaviour
{
	// Bool is activated from windowHealth script.
	public bool windowBroken = false;

	void Update ()
	{
		if(windowBroken == true)
		{
			// Starts timer to defeat.
			StartCoroutine(defeatTimer());
		}
	}
	IEnumerator defeatTimer()
	{
		// Waits for a time and changes scene.
		yield return new WaitForSeconds (5);
		Application.LoadLevel(1);
	}
}
