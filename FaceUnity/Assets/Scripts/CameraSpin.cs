using UnityEngine;
using System.Collections;

public class CameraSpin : MonoBehaviour
{		
		private float cameraDistance;
		public float cameraDistanceSpeed	;
		public float cameraDistanceMaxSpeed	;
		public float cameraDistanceAcc;
		public float cameraDistanceFriction;
		
		public float stickForce;
		public float settleGravity;
		public float friction;
		public float triggerBrake;
		
		public AnimationCurve frictionCoefficient = new AnimationCurve (new Keyframe (0, 0), new Keyframe (1, 1));
		Vector3 xyz = new Vector3 ();  //currentPosition
		Vector3 spinSpeedxyz = new Vector3 (); //Current Speed
		Vector3 settleTarget = new Vector3 ();  //Where the vector will be drawn to
		bool settleTargetPressed = false;

		public Transform cameraMain;

		// Update is called once per frame
		void Start ()
		{

				
				cameraMain = transform.GetChild (0).GetComponentInChildren<Transform> ();
				cameraDistance = 300f;
		}

		void Update ()
		{
				//Here we can press the Ltrigger past half to set the settleTarget to the current position
				if (Ctrl.LTrigger > 0.9 && !settleTargetPressed) {
						settleTarget = xyz;
						settleTargetPressed = true;
				} else if (Ctrl.LTrigger < 0.5) {
						//settleTarget = new Vector3 (0, 0, 0);
						settleTargetPressed = false;
				}

				if (Ctrl.YPressed) {
						settleTarget = new Vector3 (0, 0, 0);
				}
				
				//Here we determine how much speed is being added to the current speed, both based on the inputs
				spinSpeedxyz += new Vector3 (-Ctrl.RXStick, Ctrl.RYStick, Ctrl.LShoulder - Ctrl.RShoulder) * stickForce 
				//and how much acceleration is due to the settle Gravity		
						+ (settleTarget - xyz) * settleGravity;
				
				
				float currentFriction = 
				Mathf.Max (0.0f, (friction - (Ctrl.LTrigger * triggerBrake)))
						* frictionCoefficient.Evaluate (Mathf.Abs ((settleTarget - xyz).magnitude / (stickForce / settleGravity)));
				spinSpeedxyz *= currentFriction;
				xyz += spinSpeedxyz;
	
				Debug.Log (currentFriction);

				transform.eulerAngles = new Vector3 (xyz [1] % 360, xyz [0] % 360, xyz [2] % 360);

				
				cameraDistanceSpeed += Ctrl.DYPad * cameraDistanceAcc;
				cameraDistanceSpeed *= cameraDistanceFriction;
				cameraDistanceSpeed = Mathf.Clamp (cameraDistanceSpeed, -cameraDistanceMaxSpeed, cameraDistanceMaxSpeed);
				cameraDistance += cameraDistanceSpeed;
				cameraMain.transform.localPosition = new Vector3 (0.0f, 0.0f, cameraDistance);

				

		}

}
