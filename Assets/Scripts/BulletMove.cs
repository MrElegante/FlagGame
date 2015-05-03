using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {


	public float Speed=1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			transform.parent = transform;
			transform.position += transform.forward * Speed * Time.deltaTime;
	}
}
