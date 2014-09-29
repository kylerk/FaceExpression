using UnityEngine;
using System.Collections;



public class SpinAround : MonoBehaviour
{
		public Texture sheet;
		Sprite[] sprites;
		SpriteRenderer spriteRenderer;
		// Use this for initialization

		public GameObject player;
		//public string sheetname;
		
		public float angle;

		public float hAngle;
		public float vAngle;
		public int inframe;
		public int outframe;


		public enum spinDir
		{
				forward,
				reverse }
		;
		public spinDir spinDirection;

		void Start ()
		{
				sprites = Resources.LoadAll<Sprite> (sheet.name);
				spriteRenderer = GetComponent<SpriteRenderer> ();
				spriteRenderer.sprite = sprites [0];

		}


		void Update ()
		{

				Vector3 _position = transform.position;
				Vector3 _parentForward = transform.parent.forward;
				Vector3 towardsPlayer = player.transform.position - transform.position;

				Debug.DrawRay (_position, towardsPlayer, Color.red);
				Debug.DrawRay (_position, _parentForward, Color.green);


				Quaternion hlookDirection = Quaternion.LookRotation (towardsPlayer, Vector3.up);
			
				

				angle = hlookDirection.eulerAngles.y;
	
				transform.rotation = Quaternion.Euler (new Vector3 (0, angle, 0));
				
				hAngle = transform.localEulerAngles.y;
	


				vAngle = Vector3.Angle (transform.forward, towardsPlayer);


				Debug.DrawRay (transform.position, transform.forward);

				inframe = Mathf.Clamp (Mathf.FloorToInt (hAngle / 360 * sprites.Length), 0, sprites.Length - 1);
				

				if (spinDirection == spinDir.forward) {
						outframe = sprites.Length - 1 - inframe;
				} else if (spinDirection == spinDir.reverse) {
						outframe = inframe;
				}
		
				spriteRenderer.sprite = sprites [outframe];
		}




}
