using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{
	// Spawned object.
	public GameObject Bird;

	// The times between the spawning will happen.
	public float maxSpawnTime = 8f;
	public float minSpawnTime = 6f;

	// The time that increases.
	float time;

	// The time that will indicate when spawning happens.
	float spawnTime;

	// Decrease amount of maxSpawnTime.
	public float spawnTimeDecreaser = 0.2f;

	// Makes sure spawning can be stopped.
	public bool spawning = false;

	// Used to find script for defeat so i can stop spawning.
	public defeat defeatScript;

	void Start ()
	{
		spawning = true;

		// Rolls time to spawn between max and min.
		SetRandomTime();

		// Sets time to min. Might Spawn object immidiately.
		time = minSpawnTime;

		// Starts to decrease maxSpawnTime value.
		StartCoroutine (spawnTimeChange());

		// Finds the defeat script.
		defeatScript = GameObject.FindWithTag("defeatScript").GetComponent<defeat>();
	}
	void Update ()
	{
		// Makes sure maxSpawn doesn't go under minimum value.
		if (maxSpawnTime <= 4f)
		{
			maxSpawnTime = 4f;
		}

		// Makes sure minSpawn doesn't go under minimum value.
		if (minSpawnTime <= 2f)
		{
			minSpawnTime = 2f;
		}

		// Checks spawnTime.
		/* Debug.Log ("Dice time! " + spawnTime); */

		// Stops spawning when defeated.
		if (defeatScript.windowBroken == true)
		{
			spawning = false;
		}
	}
	void FixedUpdate()
	{
		if (spawning == true)
		{
			// Time will increase like a clock.
			time += Time.deltaTime;
	
			// Will spawn object once Time is at rolled value and rerolls the value.
			if (time >= spawnTime)
			{
				SpawnBird ();
				SetRandomTime ();
			}
		}
	}

	// Spawning function
	void SpawnBird()
	{
		// Sets Time to 0, so spawning will happen again.
		time = 0;
		Instantiate (Bird, transform.position, Bird.transform.rotation);
	}

	// Rolls a value between min and max.
	void SetRandomTime()
	{
		spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
	}

	// Decreases maxSpawnTime and minSpawnTime by a value after some time.
	IEnumerator spawnTimeChange()
	{
		while(true)
		{
			yield return new WaitForSeconds(5);
			maxSpawnTime -= spawnTimeDecreaser;
			minSpawnTime -= spawnTimeDecreaser;
		}
	}
}
