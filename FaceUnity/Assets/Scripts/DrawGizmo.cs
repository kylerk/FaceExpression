using UnityEngine;
using System.Collections;

public class DrawGizmo : MonoBehaviour
{
		
		// Use this for initialization

		void OnDrawGizmos ()
		{
				Gizmos.DrawWireSphere (transform.position, GetComponent<Attractor> ().attractionForce * 1);
		}

}
