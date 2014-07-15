using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour
{
		Ctrl ctrl = new Ctrl ();
		GameObject LStick,
				RStick,
				DPad,
				A,
				B,
				X,
				Y,
				LTrigger,
				RTrigger,
				LShoulder,
				RShoulder,
				StartBut,
				Back;


		Vector3 Aposition,
				Bposition,
				Xposition,
				Yposition,
				StartButPosition,
				BackPosition,
				LStickPosition,
				RStickPosition;

		// Use this for initialization
		void Start ()
		{
				LStick = GameObject.Find ("LStick");
				RStick = GameObject.Find ("RStick");
				DPad = GameObject.Find ("DirPad");
				A = GameObject.Find ("A");
				B = GameObject.Find ("B");
				X = GameObject.Find ("X");
				Y = GameObject.Find ("Y");
				LTrigger = GameObject.Find ("LTrigger");
				RTrigger = GameObject.Find ("RTrigger");
				LShoulder = GameObject.Find ("LShoulder");
				RShoulder = GameObject.Find ("RShoulder");
				StartBut = GameObject.Find ("Start");
				Back = GameObject.Find ("Select");

		 
				Aposition = A.transform.position;
				Bposition = B.transform.position;
				Xposition = X.transform.position;
				Yposition = Y.transform.position;
				StartButPosition = StartBut.transform.position;
				BackPosition = Back.transform.position;
				LStickPosition = LStick.transform.position;
				RStickPosition = RStick.transform.position;
		}

		// Update is called once per frame
		void Update ()
		{
			
				ctrl.updateCtrl ();
				StickTilt (LStick, 60, ctrl.LXStick, ctrl.LYStick);
				StickTilt (RStick, 60, ctrl.RXStick, ctrl.RYStick);
				ButtonPress (LStick, LStickPosition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), ctrl.LStickButton);
				ButtonPress (RStick, RStickPosition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), ctrl.RStickButton);

				StickTilt (DPad, 30, ctrl.DXPad, ctrl.DYPad);
				
				TriggerTilt (LTrigger, 60, ctrl.LTrigger);
				TriggerTilt (RTrigger, 60, ctrl.RTrigger);

				ShoulderTilt (LShoulder, 20, ctrl.LShoulder);
				ShoulderTilt (RShoulder, -20, ctrl.RShoulder);
				//A.transform.position = new Vector3 (ctrl.A, 0, 0);

				
				ButtonPress (A, Aposition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), ctrl.A);
				ButtonPress (B, Bposition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), ctrl.B);
				ButtonPress (X, Xposition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), ctrl.X);
				ButtonPress (Y, Yposition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), ctrl.Y);
				ButtonPress (StartBut, StartButPosition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), ctrl.Start);
				ButtonPress (Back, BackPosition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), ctrl.Back);

				

		}

		void StickTilt (GameObject StickObj, float tiltRange, float inputX, float inputY)
		{
				StickObj.transform.eulerAngles = new Vector3 (
			Mathf.Lerp (0, tiltRange, inputY) - tiltRange / 2,
			0,
			Mathf.Lerp (0, tiltRange, inputX) - tiltRange / 2);
				
		}

		void ButtonPress (GameObject ButtonObj, Vector3 startposition, Vector3 movement, Vector3 squash, float input)
		{
				ButtonObj.transform.position = Vector3.Lerp (startposition, startposition + movement, input);	
				ButtonObj.transform.localScale = Vector3.Lerp (new Vector3 (1, 1, 1), squash, input);
		}

		void TriggerTilt (GameObject TriggerObj, float tiltRange, float input)
		{
				TriggerObj.transform.eulerAngles = new Vector3 (

			Mathf.Lerp (0, -tiltRange, input),
			0,
			0);
		}

		void ShoulderTilt (GameObject ShoulderObj, float tiltRange, float input)
		{
				ShoulderObj.transform.eulerAngles = new Vector3 (
			0,
			Mathf.Lerp (0, -tiltRange, input),

			0);
		}


}

public class Ctrl  ////
{

		public float LYStick;
		public float LXStick;
		public float RYStick;
		public float RXStick;
		public float DYPad;
		public float DXPad;
		public float A;
		public float B;
		public float X;
		public float Y;
		public float Start;
		public float Back;
		public float LTrigger;
		public float RTrigger;
		public float LShoulder;
		public float RShoulder;
		public float LStickButton;
		public float RStickButton;	

		public void updateCtrl ()
		{
				LYStick = (Input.GetAxis ("LYStick") + 1) / 2;
				LXStick = (Input.GetAxis ("LXStick") + 1) / 2;
				RYStick = (Input.GetAxis ("RYStick") + 1) / 2;
				RXStick = (Input.GetAxis ("RXStick") + 1) / 2;

				DYPad = (Input.GetAxis ("DYPad") + 1) / 2;
				DXPad = (Input.GetAxis ("DXPad") + 1) / 2;

				A = (Input.GetAxis ("A"));
				B = (Input.GetAxis ("B"));
				X = (Input.GetAxis ("X"));
				Y = (Input.GetAxis ("Y"));

				Start = (Input.GetAxis ("Start"));
				Back = (Input.GetAxis ("Back"));

				LTrigger = (Input.GetAxis ("LTrigger"));
				RTrigger = (Input.GetAxis ("RTrigger"));
				LShoulder = (Input.GetAxis ("LShoulder"));
				RShoulder = (Input.GetAxis ("RShoulder"));
				LStickButton = (Input.GetAxis ("LStickPress"));
				RStickButton = (Input.GetAxis ("RStickPress"));
		}
}



