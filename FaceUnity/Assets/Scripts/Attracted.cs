using UnityEngine;
using System.Collections;

public class Attracted : MonoBehaviour
{


		Vector3 speed;
		public float friction;
		Attractor[] Attractors;

		// Use this for initialization
		void Start ()
		{
	
				Attractors = FindObjectsOfType (typeof(Attractor)) as Attractor[];

		}
	
		// Update is called once per frame
		void Update ()
		{

				foreach (Attractor thisAttractor in Attractors) {
						
						float distance = (thisAttractor.transform.position - transform.position).magnitude;
						speed += (thisAttractor.transform.position - transform.position) * distance * thisAttractor.attractionForce;

						speed *= friction;
						
				}
				
			

				//transform.Translate (speed);
				transform.rigidbody.AddForce (speed);

		}
}
