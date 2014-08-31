using UnityEngine;
using System.Collections;

public class CameraSpin : MonoBehaviour
{		
		
		public float stickForce;
		public float settleGravity;
		public float friction;
		public float triggerBrake;
		
		public AnimationCurve frictionCoefficient = new AnimationCurve (new Keyframe (0, 0), new Keyframe (1, 1));
		Vector3 xyz = new Vector3 ();  //currentPosition
		Vector3 spinSpeedxyz = new Vector3 (); //Current Speed
		Vector3 settleTarget = new Vector3 ();  //Where the vector will be drawn to
		bool settleTargetPressed = false;
	
		// Update is called once per frame
		void Update ()
		{
				//Here we can press the Ltrigger past half to set the settleTarget to the current position
				if (Ctrl.LTrigger > 0.5 && !settleTargetPressed) {
						settleTarget = xyz;
						settleTargetPressed = true;
				} else if (Ctrl.LTrigger < 0.5) {
						settleTarget = new Vector3 (0, 0, 0);
						settleTargetPressed = false;
				}
				
				//Here we determine how much speed is being added to the current speed, both based on the inputs
				spinSpeedxyz += new Vector3 (-Ctrl.RXStick, Ctrl.RYStick, Ctrl.LYStick) * stickForce 
				//and how much acceleration is due to the settle Gravity		
						+ (settleTarget - xyz) * settleGravity;
				
				
				float currentFriction = 
				Mathf.Max (0.0f, (friction - (Ctrl.RTrigger * triggerBrake)))
						* frictionCoefficient.Evaluate (Mathf.Abs ((settleTarget - xyz).magnitude / (stickForce / settleGravity)));
				spinSpeedxyz *= currentFriction;
				xyz += spinSpeedxyz;
	
				transform.eulerAngles = new Vector3 (xyz [1] % 360, xyz [0] % 360, xyz [2] % 360);
		}
}
