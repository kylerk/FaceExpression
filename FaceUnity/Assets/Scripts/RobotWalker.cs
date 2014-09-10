using UnityEngine;
using System.Collections;

public class RobotWalker : MonoBehaviour
{
		

		public AnimationCurve walkDetect;
		public AnimationCurve walkDetectDirection;
		public float distanceDetect;
		public float positionDistanceDetect;
		public float lateralAngle;
		public float speed;
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
				//Debug.DrawRay (transform.position, transform.up * 30, Color.green, 10.0f);
				
				//transform.localPosition += robot.transform.forward * -Ctrl.LYStick;
				Vector3 newposition = transform.position 
						+ robot.transform.forward * -Ctrl.LYStick
						+ transform.up * 5.0f;
							
				if (Physics.Raycast (newposition, -transform.up, out hit, 1000.0f, layerMask)) {
						

						Debug.DrawLine (newposition, hit.point, Color.cyan, 12.0f);
				
						
				}

				
				transform.position = hit.point;
				
			
				robotAverageNormal = Vector3.zero;
			

				for (int j = -3; j<3; j++) {
						for (int i=-10; i<10; i++) {
								float heightDetect = walkDetect.Evaluate (i / 10f);
								float directionDetect = walkDetectDirection.Evaluate (i / 10f);
								Vector3 pointA = transform.position 
										+ transform.up * heightDetect 
										+ robot.transform.right * j * 2.0f
										+ robot.transform.forward * i * 1.5f;
								Vector3 pointB = (-transform.up 
										+ -robot.transform.forward * i * directionDetect
										+ -robot.transform.right * j * lateralAngle
				                  		);
								if (Physics.Raycast (pointA, pointB, out hit, distanceDetect, layerMask)) {
										Debug.DrawRay (pointA, pointB, Color.magenta, 0, false);			
										Debug.DrawLine (pointA, hit.point);
						
										robotAverageNormal += hit.normal;
								}
						}

				}
				
				Debug.DrawRay (transform.position, robotAverageNormal, Color.blue, 1.0f);
				

				transform.up = robotAverageNormal;
				

				//transform.rotation = Quaternion.FromToRotation (transform.up, robotAverageNormal);
				heading += Ctrl.LXStick * 3;
				robot.transform.Rotate (0, Ctrl.LXStick * 5, 0);

		}



		void groundToSurface ()
		{


		}
}
