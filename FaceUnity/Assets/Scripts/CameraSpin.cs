using UnityEngine;
using System.Collections;

public class CameraSpin : MonoBehaviour
{		
		Ctrl ctrl ;
		float spinSpeedx;
		float spinSpeedy;
		void Start ()
		{
				ctrl = ControllerInput.ctrl;
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (ctrl.LTrigger > 0.2) {
						spinSpeedx = -ctrl.LXStick * ctrl.LTrigger;
						spinSpeedy = -ctrl.LYStick * ctrl.LTrigger;
						transform.Rotate (10f * spinSpeedy, 10f * spinSpeedx, 0);
				}

		}
}
