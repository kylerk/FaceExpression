using UnityEngine;
using System.Collections;

public class CreateCapsules : MonoBehaviour
{

		GameObject capsule;

		// Use this for initialization
		void Start ()
		{
				capsule = Resources.Load ("AttractedThing") as GameObject;
		}
	
		// Update is called once per frame
		void Update ()
		{
	

				if (Ctrl.APressed) {
						GameObject newCapsule = Instantiate (capsule) as GameObject;
						newCapsule.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 50;

				}
			
		
		}
}
