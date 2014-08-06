using UnityEngine;
using System.Collections;

public class SurfaceWalker : MonoBehaviour
{

		public GameObject surface;
		public Vector3 starttarget;
		public Vector3 target;
		RaycastHit hit;
		Vector3 direction;
		// Use this for initialization
		void Start ()
		{
				direction = surface.transform.position - transform.position;
				Physics.Raycast (transform.position, direction, out hit, 10000f);
				transform.position = hit.point;
				
		}
	
		// Update is called once per frame
		void Update ()
		{		
				Vector3 normal = new Vector3 (0, 1, 0);
				RaycastHit hit;
				
				
				Vector3 direction = target - starttarget;

				//Debug.Log (direction);
				Physics.Raycast (transform.position + normal * 30, direction, out hit, 10000f);
				Debug.DrawLine (transform.position + normal * 30, direction, Color.cyan, 0, false);
				normal = hit.normal;
				transform.position = hit.point;
				transform.Translate (-Ctrl.LXStick, 0, Ctrl.LYStick);
				starttarget = transform.position + hit.normal * 10;
				target = hit.point - hit.normal * 10;
				

				Debug.DrawLine (target, hit.point, Color.green, 0, false);
				Debug.DrawRay (hit.point, hit.normal * 20, Color.blue, 0, false);

				Debug.DrawRay (transform.position, transform.forward * 20, Color.red, 0, false);

		}



}
