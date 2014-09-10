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
		public GameObject polevector;
		GameObject pointer;

		// Use this for initialization
		void Start ()
		{
				Physics.Raycast (transform.position, -transform.up, out hit, 10000f);
				transform.position = hit.point;
				transform.up = hit.normal;
				robot = GameObject.Find ("Robot");
				pointer = new GameObject ();
				pointer.transform.position = transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
				
				Vector3 newposition = transform.position 
						+ robot.transform.forward * -Ctrl.LYStick * speed
						+ transform.up * 5.0f;
							
				if (Physics.Raycast (newposition, -transform.up, out hit, 1000.0f, layerMask)) {
						//	Debug.DrawLine (newposition, hit.point, Color.cyan, 12.0f);
				
		
						
				}
				
				
				//  Old version,  Now we have a max speed. transform.position = hit.point;
		
				Vector3 moveVector = hit.point - transform.position;
				if (moveVector.magnitude > speed) {
						transform.position += moveVector.normalized * speed;
				} else {
						transform.position += moveVector;
				}

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
				
				Debug.DrawRay (transform.position, robotAverageNormal, Color.blue, 1.0f);
				
				//	pointer.transform.position = transform.position;

				//	pointer.transform.rotation = Quaternion.LookRotation (robotAverageNormal, polevector.transform.position - pointer.transform.position);
				Debug.DrawRay (pointer.transform.position, pointer.transform.up * 10, Color.green);
				Debug.DrawRay (pointer.transform.position, pointer.transform.forward * 10, Color.blue);
				Debug.DrawRay (pointer.transform.position, pointer.transform.right * 10, Color.red);
				
				


				


				//transform.rotation = Quaternion.RotateTowards (transform.rotation, pointer.transform.rotation * Quaternion.Euler (90, 0, 0), 3f);

				transform.up = robotAverageNormal;
				robot.transform.Rotate (0, Ctrl.LXStick * 5, 0);

		}



		
}
