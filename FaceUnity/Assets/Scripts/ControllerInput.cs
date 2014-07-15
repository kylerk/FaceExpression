using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour
{
		Ctrl ctrl = new Ctrl ();
		GameObject LStick ;
		GameObject RStick ;
		GameObject DPad ;
		GameObject A;
		GameObject B;
		GameObject X;
		GameObject Y;
		GameObject LTrigger;
		GameObject RTrigger;
		GameObject LShoulder;
		GameObject RShoulder;
		GameObject StartBut;
		GameObject Back;

		

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
				Back = GameObject.Find ("Back");
	
		}

		// Update is called once per frame
		void Update ()
		{
			
				ctrl.updateCtrl ();


				LStick.transform.eulerAngles = new Vector3 (
													Mathf.Lerp (0, 60, ctrl.LYStick) - 30,
		                                            0,
		                                            Mathf.Lerp (0, 60, ctrl.LXStick) - 30);
				RStick.transform.eulerAngles = new Vector3 (
													Mathf.Lerp (0, 60, ctrl.RYStick) - 30,
													0,
													Mathf.Lerp (0, 60, ctrl.RXStick) - 30);
				

				DPad.transform.eulerAngles = new Vector3 (
													Mathf.Lerp (0, 10, ctrl.DYPad) - 5,
													0,
													Mathf.Lerp (0, 10, ctrl.DXPad) - 5);
				
				//A.transform.position = new Vector3 (ctrl.A, 0, 0);

				A.transform.localPosition = new Vector3 (ctrl.A, 0, 0);
				
				Debug.Log (ctrl.A);
	
		}

}

public class Ctrl
{

		public float LYStick;
		public float LXStick;
		public float RYStick;
		public float RXStick;
		public float DYPad;
		public float DXPad;
		public float A;


		public void updateCtrl ()
		{
				LYStick = (Input.GetAxis ("LYStick") + 1) / 2;
				LXStick = (Input.GetAxis ("LXStick") + 1) / 2;
				RYStick = (Input.GetAxis ("RYStick") + 1) / 2;
				RXStick = (Input.GetAxis ("RXStick") + 1) / 2;

				DYPad = (Input.GetAxis ("DYPad") + 1) / 2;
				DXPad = (Input.GetAxis ("DXPad") + 1) / 2;

				A = (Input.GetAxis ("A"));
		}
}



