using UnityEngine;
using System.Collections;

public class InstantiateOnDestroy : MonoBehaviour {

	public Transform NewObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnDestroy () {
		Instantiate (NewObject, transform.position, transform.rotation);
	}
}
