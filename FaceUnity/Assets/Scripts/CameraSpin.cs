using UnityEngine;
using System.Collections;

public class CameraSpin : MonoBehaviour
{		
		float spinSpeedx;
		float spinSpeedy;
		
	
		// Update is called once per frame
		void Update ()
		{
				if (Ctrl.LTrigger > 0.2) {
						spinSpeedx = -Ctrl.LXStick * Ctrl.LTrigger;
						spinSpeedy = -Ctrl.LYStick * Ctrl.LTrigger;
						transform.Rotate (10f * spinSpeedy, 10f * spinSpeedx, 0);
				}

		}
}
