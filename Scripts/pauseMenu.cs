using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour
{
	// Assing panel from canvas here. It goes with the same name.
	public GameObject pauseMenuPanel;

	bool pausedGame = false;

	void Start ()
	{
		// Makes sure game isn't paused in start.
		pausedGame = false;
	}

	void Update ()
	{
		// Stops game.
		if (pausedGame == true)
		{
			Time.timeScale = 0f;
		}

		// Starts game.
		if (pausedGame == false)
		{
			Time.timeScale = 1.0f;
		}
	}

	// Toggles bool with click using canvas UI button.
	public void PauseActivate ()
	{
		pausedGame = !pausedGame;
	}
	public void ResetGame ()
	{

	}
}
