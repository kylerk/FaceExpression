using UnityEngine;
using System.Collections;

public class CameraSpin : MonoBehaviour
{		
		
		public float stickForce;
		public float settleGravity;
		public float friction;
		public AnimationCurve frictionCoefficient = new AnimationCurve (new Keyframe (0, 0), new Keyframe (1, 1));
		float spinSpeedx;
		float spinSpeedy;
		float x = 0;
		float y = 0;	
		

	
		// Update is called once per frame
		void Update ()
		{
				//Attribute a certain point, spinSpeedx will reach an equilibrium where stick force no longer adds any more
				spinSpeedx += -Ctrl.RXStick * stickForce;
				spinSpeedx -= settleGravity * x;
				
				spinSpeedy += Ctrl.RYStick * stickForce;
				spinSpeedy -= settleGravity * y;

			
				x += spinSpeedx;
				y += spinSpeedy;
				spinSpeedx *= friction * frictionCoefficient.Evaluate (Mathf.Abs (x / (stickForce / settleGravity)));
				spinSpeedy *= friction * frictionCoefficient.Evaluate (Mathf.Abs (y / (stickForce / settleGravity)));
				//	Debug.Log ("rangemap:" + Mathf.Abs (x / (stickForce / settleGravity)));
				//		Debug.Log ("frictionEva:" + Mathf.Abs (x * stickForce / settleGravity));
				//Debug.Log ("y:" + x);
				transform.eulerAngles = new Vector3 (y % 360, x % 360, 0);

		}
}
