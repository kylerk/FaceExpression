using UnityEngine;
using System.Collections;

public class CameraSpin : MonoBehaviour
{		
		Ctrl ctrl ;
		float spinSpeed;
		void Start ()
		{
				ctrl = ControllerInput.ctrl;
		
		}
	
		// Update is called once per frame
		void Update ()
		{

				//spinSpeed = ctrl.LTrigger * ctrl.RTrigger ;
				transform.Rotate (0, 10f * spinSpeed, 0);
		}
}
