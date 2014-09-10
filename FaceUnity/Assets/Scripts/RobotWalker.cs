using UnityEngine;
using System.Collections;

public class RobotWalker : MonoBehaviour
{
		
		RaycastHit hit;
		float heading = 0f;
		GameObject robot;
		int layerMask = 1 << 8;
		Vector3 robotAverageNormal;

		// Use this for initialization
		void Start ()
		{
				Physics.Raycast (transform.position, -transform.up, out hit, 10000f);
				transform.position = hit.point;
				transform.up = hit.normal;
				robot = GameObject.Find ("Robot");
		}
	
		// Update is called once per frame
		void Update ()
		{
				
				
				transform.localPosition += robot.transform.forward * -Ctrl.LYStick;

							

				Physics.Raycast (transform.position + transform.up * 1, -transform.up, out hit, 10000f);
				transform.position = hit.point;
				robotAverageNormal = Vector3.zero;
			
				for (int i=-10; i<10; i++) {
						Vector3 pointA = transform.position + transform.up * 1 + robot.transform.forward * i * 1.0f;
						Vector3 pointB = (-transform.up + -robot.transform.forward * i * 0.1f);
						if (Physics.Raycast (pointA, pointB, out hit, 100f, layerMask)) {
								Debug.DrawRay (pointA, pointB, Color.magenta, 0, false);			
								Debug.DrawLine (pointA, hit.point);
						
								robotAverageNormal += hit.normal;
						}

				}
				
				Debug.Log (robotAverageNormal);
				transform.up = robotAverageNormal;
			
				heading += Ctrl.LXStick * 3;
				robot.transform.Rotate (0, Ctrl.LXStick * 5, 0);

		}



		void groundToSurface ()
		{


		}
}
