using UnityEngine;
using System.Collections;

public class RobotWalker : MonoBehaviour
{
		
		RaycastHit hit;
		float heading = 0f;
		GameObject Robot;

		// Use this for initialization
		void Start ()
		{
				Physics.Raycast (transform.position, -transform.up, out hit, 10000f);
				transform.position = hit.point;
				transform.up = hit.normal;
				Robot = GameObject.Find ("Robot");
		}
	
		// Update is called once per frame
		void Update ()
		{
				
				
				transform.localPosition += Robot.transform.forward * -Ctrl.LYStick;

				Debug.DrawRay (transform.position, transform.forward * 20, Color.blue, 0, false);
				Debug.DrawRay (transform.position, transform.up * 20, Color.magenta, 0, false);

				Physics.Raycast (transform.position + transform.up * 4, -transform.up, out hit, 10000f);
				transform.position = hit.point;
				
				transform.up = hit.normal;
				heading += Ctrl.LXStick * 3;
				Robot.transform.Rotate (0, Ctrl.LXStick * 5, 0);

		}



		void groundToSurface ()
		{


		}
}
