using UnityEngine;
using System.Collections;

public class WayPoints: MonoBehaviour 
 {
		
		// Use this for initialization
		public List<Transform> wayPoints = new List<Transform>();
		
		public float speed = 1.0f;
		public int index;
		public Vector3 Force;
		private  Vector3 velocity = Vector3.zero;
		
		
		
		void Start () 
		{
			Invoke("StartTimer",60);
			
		}
		
		// Update is called once per frame
		void Update () 
			
		{
			if (speed > float.Epsilon)
			{
				transform.forward = velocity;
				
			}
			Force = Vector3.zero;
			
			
			
			Debug.Log(Time.time);
			if(index == 10)
			{
				index = 0;
			}
			
			
			
			Vector3 direction = wayPoints[index].transform.position - transform.position;
			direction.Normalize();
			var distance = Vector3.Distance(wayPoints[index].transform.position,transform.position);
			
			if (distance<1.0f)
			{
				index = index + 1;
				
				
			}
			
			
			
			
			transform.Translate(direction * Time.deltaTime * speed);
		}
		
		void StartTimer()
		{
			StartCoroutine(Idle1());
			
		}
		
		IEnumerator Idle1()
			
		{
			
			speed = 15f;
			yield return new WaitForSeconds(0.5f);
			speed = 10f;
			yield return new WaitForSeconds(0.5f);
			speed = 5f;
			yield return new WaitForSeconds(0.5f);
			speed = 0f;
			
			
			
			
			
		}
		
		
		
	}