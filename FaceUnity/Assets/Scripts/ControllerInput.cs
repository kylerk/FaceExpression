using UnityEngine;
using System.Collections;
using System.Reflection;

public class ControllerInput : MonoBehaviour
{
		
		//	public static Ctrl ctrl = new Ctrl () ;

		//Gameobjects to Hold all the pieces of the Game Controller Model
		GameObject 	LStick,
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
		// Vector3 to hold the Initial Position of some of the pieces of the model
		Vector3 Aposition,
				Bposition,
				Xposition,
				Yposition,
				StartButPosition,
				BackPosition,
				LStickPosition,
				RStickPosition;

		void Start ()
		{
				//Link the Game Object Holders to the 
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
			
				Ctrl.updateCtrl ();


				StickTilt (LStick, 60, Ctrl.LXStick, Ctrl.LYStick);
				StickTilt (RStick, 60, Ctrl.RXStick, Ctrl.RYStick);
				ButtonPress (LStick, LStickPosition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), Ctrl.LStickButton);
				ButtonPress (RStick, RStickPosition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), Ctrl.RStickButton);

				StickTilt (DPad, 30, Ctrl.DXPad, Ctrl.DYPad);
				
				TriggerTilt (LTrigger, 60, Ctrl.LTrigger);
				TriggerTilt (RTrigger, 60, Ctrl.RTrigger);

				ShoulderTilt (LShoulder, 20, Ctrl.LShoulder);
				ShoulderTilt (RShoulder, -20, Ctrl.RShoulder);
				//A.transform.position = new Vector3 (ctrl.A, 0, 0);

				
				ButtonPress (A, Aposition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), Ctrl.A);
				ButtonPress (B, Bposition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), Ctrl.B);
				ButtonPress (X, Xposition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), Ctrl.X);
				ButtonPress (Y, Yposition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), Ctrl.Y);
				ButtonPress (StartBut, StartButPosition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), Ctrl.Start);
				ButtonPress (Back, BackPosition, new Vector3 (0, -3, 0), new Vector3 (1.4f, 0.5f, 1.4f), Ctrl.Back);

		}

		void OnGUI ()
		{
				int i = 0;
				foreach (FieldInfo field in typeof(Ctrl).GetFields()) {
					
						if (field.GetValue (typeof(Ctrl)).GetType () != typeof(bool)) {

								GUI.Box (new Rect (051 * i, 
			                  					0, 
			                   					50, 
			                   					100.0f + (float)field.GetValue (typeof(Ctrl)) * 50.0f),

			         field.Name + "\n" + ((float)field.GetValue (typeof(Ctrl))).ToString ("F2"));
						}
						i++;
						
						//	Debug.Log (w.ToString ("F1"));
				}

		}





		void StickTilt (GameObject StickObj, float tiltRange, float inputX, float inputY)
		{
				StickObj.transform.localEulerAngles = new Vector3 (
			Mathf.Lerp (0, tiltRange, (inputY + 1) / 2) - tiltRange / 2,
			0,
			Mathf.Lerp (0, tiltRange, (inputX + 1) / 2) - tiltRange / 2);
				
		}

		void ButtonPress (GameObject ButtonObj, Vector3 startposition, Vector3 movement, Vector3 squash, float input)
		{
				ButtonObj.transform.position = Vector3.Lerp (startposition, startposition + movement, input);	
				ButtonObj.transform.localScale = Vector3.Lerp (new Vector3 (1, 1, 1), squash, input);
		}

		void TriggerTilt (GameObject TriggerObj, float tiltRange, float input)
		{
				TriggerObj.transform.localEulerAngles = new Vector3 (

			Mathf.Lerp (0, -tiltRange, input),
			0,
			0);
		}

		void ShoulderTilt (GameObject ShoulderObj, float tiltRange, float input)
		{
				ShoulderObj.transform.localEulerAngles = new Vector3 (
			0,
			Mathf.Lerp (0, -tiltRange, input),

			0);
		}




}

public static class Ctrl  ////  THe Class where the inputs reside.
{

		public static float LYStick,
				LXStick,
				RYStick,
				RXStick,
				DYPad,
				DXPad,
				A,
				B,
				X,
				Y,
				Start,
				Back,
				LTrigger,
				RTrigger,
				LShoulder,
				RShoulder,
				LStickButton,
				RStickButton;	

		public static bool APressed;

		public static void updateCtrl ()
		{
				LYStick = (Input.GetAxis ("LYStick"));
				LXStick = (Input.GetAxis ("LXStick"));
				RYStick = (Input.GetAxis ("RYStick"));
				RXStick = (Input.GetAxis ("RXStick"));

				DYPad = (Input.GetAxis ("DYPad"));
				DXPad = (Input.GetAxis ("DXPad"));

				A = (Input.GetAxis ("A"));
				APressed = (Input.GetButtonDown ("A"));
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



