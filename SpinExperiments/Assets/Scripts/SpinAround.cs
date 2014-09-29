using UnityEngine;
using System.Collections;

public class SpinAround : MonoBehaviour
{

		Sprite[] sprites;
		SpriteRenderer spriteRenderer;
		// Use this for initialization

		public GameObject player;


		void Start ()
		{
				sprites = Resources.LoadAll<Sprite> ("GuySpin_V_1_w162_H285");
				spriteRenderer = GetComponent<SpriteRenderer> ();
				spriteRenderer.sprite = sprites [0];
		}


		void FixedUpdate ()
		{
		
				//transform.forward = transform.position - player.transform.position;
			
				Quaternion lookDirection = Quaternion.LookRotation (transform.position - player.transform.position, Vector3.up) * Quaternion.Euler (0, 1, 0);
			
				transform.rotation = Quaternion.Euler (new Vector3 (0, lookDirection.eulerAngles.y, 0));


				int frame = Mathf.FloorToInt ((transform.eulerAngles.y - transform.parent.eulerAngles.y) / 360 * sprites.Length);
				
				spriteRenderer.sprite = sprites [frame];
				//Debug.Log (frame);
				//Debug.Log (transform.eulerAngles.y);
		}
		// Update is called once per frame
		void Update ()
		{
	
		}


}
