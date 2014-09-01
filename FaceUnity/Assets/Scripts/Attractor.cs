using UnityEngine;
using System.Collections;

public class Attractor : MonoBehaviour
{


		public float attractionForce;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				// Just a control to make sure the attractor is working.
				transform.Translate (-Ctrl.DXPad, -Ctrl.DYPad, 0);
		}
}
