using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour {
	public GameObject Other;
	public float DestroyTime = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (Other, DestroyTime);
	}
}
