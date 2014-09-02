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
				StartCoroutine (CalculateSpeed ());
		}
		void OncCollisionStay ()
		{
				speed = Vector3.zero;
		}
		// Update is called once per frame
		void Update ()
		{

				/*	foreach (Attractor thisAttractor in Attractors) {
						float distance = (thisAttractor.transform.position - transform.position).magnitude;
						speed += (thisAttractor.transform.position - transform.position) * distance * thisAttractor.attractionForce;
						speed *= friction;
				}
			*/
				//transform.Translate (speed);
				
				speed *= friction;
				transform.rigidbody.AddForce (speed);
				

		}

		private IEnumerator CalculateSpeed ()
		{
				while (true) {
					
						foreach (Attractor thisAttractor in Attractors) {
								float distance = (thisAttractor.transform.position - transform.position).magnitude;
								speed += (thisAttractor.transform.position - transform.position).normalized * thisAttractor.attractionForce / distance / distance * 100000;
						}

						yield return new WaitForSeconds (Random.Range (0.4f, 5.0f));

				}



		}
}
