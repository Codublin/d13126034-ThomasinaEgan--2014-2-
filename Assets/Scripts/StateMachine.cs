using System;
using System.Collections;
using UnityEngine;

public class StateMachine:MonoBehaviour
{
	State currentState;
	
	[SerializeField]
	private String state;
	public int ammo;
	public int health;
	
	public GameObject currentTarget;
	
	void Start()
	{
		ammo = 10;
		health = 10;
		state = "No state set";
	}
	
	public void Update()
	{
		if (currentState != null)
		{
			//Debug.Log("Current state: " + currentState.Description());
			currentState.Update();
		}
		
		if (health <=4)
		{
			
			GameObject[] healthBoxes = GameObject.FindGameObjectsWithTag("health");
			GameObject nearestHealth = null;
			float minDist = Mathf.Infinity;
			foreach (GameObject ammoBox in healthBoxes)
			{
				float distance = Vector3.Distance(ammoBox.transform.position, transform.position);
				if (distance < minDist)
				{
					nearestHealth = ammoBox;
					minDist = distance;
				}
			}
			if (nearestHealth != null)
			{
				currentTarget = nearestHealth;
				SwitchState(new FindHealthState(gameObject, nearestHealth));
			}   
		}
		if (health <= 0)
		{
			//Debug.Log(gameObject.name+ " died!");
			StartCoroutine(disableDelay(4.0f));
		}
	}
	
	IEnumerator disableDelay(float seconds)
	{
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		yield return new WaitForSeconds(seconds);
		gameObject.GetComponent<MeshRenderer>().enabled = true;
		//restore health
		health = 20;
		
	}
	
	public void SwitchState(State newState)
	{
		state = newState.Description();
		if (currentState != null)
		{
			currentState.Exit();
		}
		
		currentState = newState;
		if (newState != null)
		{
			
			currentState.Enter();
		}
	}
}