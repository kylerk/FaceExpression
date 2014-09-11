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
		GameObject robot;
		int layerMask = 1 << 8;
		Vector3 robotAverageNormal;
		GameObject pointForward;
		GameObject pointForward2;

		public float x, y, z, x2, y2, z2;
		// Use this for initialization
		void Start ()
		{
				Physics.Raycast (transform.position, -transform.up, out hit, 10000f);
				transform.position = hit.point;
				transform.up = hit.normal;
				robot = GameObject.Find ("Robot");
				pointForward = new GameObject ();
				pointForward.transform.position = transform.position;
				pointForward2 = new GameObject ();
				pointForward.transform.position = transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
				
				Vector3 newPositionCheck = transform.position 
						+ robot.transform.forward * -Ctrl.LYStick * speed
						+ transform.up * 5.0f;
							
				if (Physics.Raycast (newPositionCheck, -transform.up, out hit, 1000.0f, layerMask)) {
						//	Debug.DrawLine (newposition, hit.point, Color.cyan, 12.0f);
				}
				
				
				//  Old version,  Now we have a max speed. transform.position = hit.point;
		
				Vector3 moveVector = hit.point - transform.position;
				if (moveVector.magnitude > speed) {
						transform.position += moveVector.normalized * speed;
				} else {
						transform.position += moveVector;
				}

				//Find the AverageNormal of the surrounding area.

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
										//	Debug.DrawRay (pointA, pointB, Color.magenta, 0, false);			
										//	Debug.DrawLine (pointA, hit.point);
						
										robotAverageNormal += hit.normal;
								}
						}

				}
				
				//Debug.DrawRay (transform.position, robotAverageNormal, Color.blue, 1.0f);
			

				pointForward.transform.position = transform.position;



				Debug.DrawRay (pointForward.transform.position, pointForward.transform.up * 10, Color.green);
				Debug.DrawRay (pointForward.transform.position, pointForward.transform.forward * 10, Color.blue);
				Debug.DrawRay (pointForward.transform.position, pointForward.transform.right * 10, Color.red);
				
				pointForward.transform.rotation = Quaternion.LookRotation (robotAverageNormal, pointForward.transform.up);

				pointForward.transform.Rotate (0, 0, Ctrl.LXStick * 5);



				

		
				Debug.DrawRay (pointForward.transform.position, pointForward.transform.up * 10, Color.green);
				Debug.DrawRay (pointForward.transform.position, pointForward.transform.forward * 10, Color.blue);
				Debug.DrawRay (pointForward.transform.position, pointForward.transform.right * 10, Color.red);
				

				pointForward2.transform.position = pointForward.transform.position;
				pointForward2.transform.rotation = pointForward.transform.rotation;

				//		pointForward2.transform.Rotate (pointForward2.transform.up, 45f);

				pointForward2.transform.rotation = pointForward2.transform.rotation * Quaternion.Euler (x, y, z) * Quaternion.Euler (x2, y2, z2);
				
				Debug.DrawRay (pointForward2.transform.position, pointForward2.transform.up * 20, Color.yellow);
				Debug.DrawRay (pointForward2.transform.position, pointForward2.transform.forward * 20, Color.cyan);
				Debug.DrawRay (pointForward2.transform.position, pointForward2.transform.right * 20, Color.magenta);


				//transform.rotation = Quaternion.RotateTowards (transform.rotation, pointForward.transform.rotation * Quaternion.Euler (90, 0, 0), 3f);

				transform.up = robotAverageNormal;
				//robot.transform.Rotate (0, Ctrl.LXStick * 5, 0);

				robot.transform.rotation = pointForward2.transform.rotation;
				
		}



		
}
