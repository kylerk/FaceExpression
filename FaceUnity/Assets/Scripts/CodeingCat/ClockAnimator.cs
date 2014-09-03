using UnityEngine;
using System;
public class ClockAnimator : MonoBehaviour
{
		private const float
				hoursToDegrees = 360f / 12f,
				minutesToDegrees = 360f / 60f,
				secondsToDegrees = 360f / 60f;

		public Transform hours, minutes, seconds;

		public bool analog;
		
		void Update ()
		{
				if (analog) {
						TimeSpan timespan = DateTime.Now.TimeOfDay;
						hours.localRotation = Quaternion.Euler (0F, 0F, (float)timespan.TotalHours * -hoursToDegrees);
						minutes.localRotation = Quaternion.Euler (0F, 0F, (float)timespan.TotalMinutes * -minutesToDegrees);
						seconds.localRotation = Quaternion.Euler (0F, 0F, (float)timespan.TotalSeconds * -secondsToDegrees);
				} else {
						DateTime time = DateTime.Now;
						hours.localRotation = Quaternion.Euler (0F, 0F, time.Hour * -hoursToDegrees);
						minutes.localRotation = Quaternion.Euler (0F, 0F, time.Minute * -minutesToDegrees);
						seconds.localRotation = Quaternion.Euler (0F, 0F, time.Second * -secondsToDegrees);
				}
		}

}
