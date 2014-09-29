using UnityEngine;
using System.Collections;

public class RobotWalker : MonoBehaviour
{
		

		public AnimationCurve walkDetect;
		public AnimationCurve walkDetectDirection;
		public float distanceDetect;
		public float positionDistanceDetect;
		public float lateralAngle;
		public float speed, rotationSpeed;
		RaycastHit hit;
		GameObject robot;
		int layerMask = 1 << 8;
		Vector3 robotAverageNormal;




		void Start ()
		{
				Physics.Raycast (transform.position, -transform.up, out hit, 10000f);
				transform.position = hit.point;
				transform.up = hit.normal;
				robot = GameObject.Find ("Robot");

			
		}
	

		void Update ()
		{
				Transform _transform = transform;
				Vector3 newPositionCheck = _transform.position 
						+ _transform.forward * -Ctrl.LYStick * speed
						+ _transform.up * 5.0f;
							
				if (Physics.Raycast (newPositionCheck, -_transform.up, out hit, 1000.0f, layerMask)) {
						//	Debug.DrawLine (newposition, hit.point, Color.cyan, 12.0f);
				}
				

				//  Old version,  Now we have a max speed. transform.position = hit.point;
		
				Vector3 moveVector = hit.point - _transform.position;
				if (moveVector.magnitude > speed) {
						transform.position += moveVector.normalized * speed;
				} else {
						transform.position += moveVector;
				}

				//Find the AverageNormal of the surrounding area.
					
				_transform = transform;
					
				robotAverageNormal = Vector3.zero;
				for (int j = -3; j<3; j++) {
						for (int i=-10; i<10; i++) {
								float heightDetect = walkDetect.Evaluate (i / 10f);
								float directionDetect = walkDetectDirection.Evaluate (i / 10f);
								Vector3 pointA = _transform.position 
										+ _transform.up * heightDetect 
										+ _transform.right * j * 2.0f
										+ _transform.forward * i * 1.5f;
								Vector3 pointB = (-_transform.up 
										+ -_transform.forward * i * directionDetect
										+ -_transform.right * j * lateralAngle
				                  		);
								if (Physics.Raycast (pointA, pointB, out hit, distanceDetect, layerMask)) {
										//	Debug.DrawRay (pointA, pointB, Color.magenta, 0, false);			
										//	Debug.DrawLine (pointA, hit.point);
						
										robotAverageNormal += hit.normal;
								}
						}

				}
				
				//Debug.DrawRay (transform.position, robotAverageNormal, Color.blue, 1.0f);
			
				transform.rotation = Quaternion.LookRotation (robotAverageNormal, transform.forward) * Quaternion.Euler (0, 0, Ctrl.LXStick * rotationSpeed) * Quaternion.Euler (90, 0, 0) * Quaternion.Euler (0, 180, 0);
			

		}



		
}
