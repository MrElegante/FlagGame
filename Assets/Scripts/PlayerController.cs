using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float Speed=1;
	public float RotationSpeed=90;	
	void Update()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			transform.position += transform.forward * Speed * Time.deltaTime;

		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			transform.position -= transform.forward * Speed * Time.deltaTime;

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(new Vector3(0, -RotationSpeed * Time.deltaTime, 0));

		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(new Vector3(0, RotationSpeed * Time.deltaTime, 0));
	}
}
