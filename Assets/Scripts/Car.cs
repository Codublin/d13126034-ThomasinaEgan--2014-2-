using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
	//holds our gameobjects that are used for waypoints
	public List<Transform> wayPoints = new List<Transform>();
	
	public float speed = 1.0f;
	public int index;
	
	// Update is called once per frame
	void Update () 
	{
		//calculates the distance from the current waypoint, and the cube
		var distance = Vector3.Distance(wayPoints[index].transform.position, transform.position);
		
		if (distance < 0.5f)
		{
			//assign new waypoint only if distance is less than .5
			index = Random.Range(0, wayPoints.Count);
		}
		
		//calculates the current way points position, and my position and subtract 
		//so i know the distance needed to travel
		Vector3 direction = wayPoints[index].transform.position - transform.position;
		direction.Normalize();
		transform.Translate(direction * Time.deltaTime * speed);
		
		Debug.DrawLine(transform.position, wayPoints[index].transform.position, Color.red);
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = (isActive) ? Color.yellow : Color.red;
		Gizmos.DrawCube(position, new Vector3(1, 1, 1));
		
		foreach (WaypointNode n in neighbors)
		{
			if (n != null)
			{
				Gizmos.color = (isActive) ? Color.yellow : Color.red;
				Gizmos.DrawLine(position + Vector3.up * 0.5F, n.position + Vector3.up * 0.5F);
			}
		}
	}
}