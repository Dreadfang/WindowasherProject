using UnityEngine;
using System.Collections;

public class HissiMovement : MonoBehaviour {

	//This gets the elovators transform.position so that it can be used at the start to determine where the elovator start at.
	public Transform ElovatorPlace;
	
	//These are the 3 different floors. These are use to get the transform.position for Target variable.
	//These Floors are actually the window positions.
	public Transform Floor_1;
	public Transform Floor_2;
	public Transform Floor_3;

	//This is the target used to say where the elovator needs to go.
	//Floor_1, Floor_2, Floor_3 are the targets and Target is the curren destination fo the elovator.
	public Transform Target;

	//This value is used to check what floor the player is currently on.
	//It is also used to change the Target value.
	public int currentFloor = 2;

	//Start is used to set up the starting conditons in the level.
	void Start () 
	{
		//This sets the starting elovator position to be on floor 2.
		ElovatorPlace.transform.position = Floor_2.transform.position;

		//Sets the Target to Floor_2 so the elovator doesn't move as soon as you play the level.
		Target = Floor_2;

		//
		currentFloor = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector2.Lerp(transform.position, Target.transform.position, 0.1f);
		if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			GoUpALevel();
		}
		if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			GoDownALevel();
		}
		if(currentFloor >= 3)
		{
			currentFloor = 3;
		}
		if(currentFloor <= 1)
		{
			currentFloor = 1;
		}
		Debug.Log (Target);
	}
	void GoUpALevel()
	{

		if(currentFloor == 1)
		{
			Target = Floor_2;
		}
		if(currentFloor == 2)
		{
			Target = Floor_3;
		}
		currentFloor += 1;
	}
	void GoDownALevel()
	{

		if(currentFloor == 3)
		{
			Target = Floor_2;
		}
		if(currentFloor == 2)
		{
			Target = Floor_1;
		}
		currentFloor -= 1;
	}
}
