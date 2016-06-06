using UnityEngine;
using System.Collections;

public class RaycastManager : MonoBehaviour {

	public LayerMask layerMask;
	public float raycastDistance;
	public float timer;

	// Use this for initialization
	void Start () {
		Cardboard.SDK.VRModeEnabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();

		if(Cardboard.SDK.Triggered){
			Debug.Log ("Triggered!");
			GameObject.Find ("Cube").GetComponent<Renderer> ().material.color = Color.red;
		}
	}

	void Raycasting(){
		Vector3 fwd = GetComponentInChildren<Camera> ().transform.TransformDirection (Vector3.forward);
		RaycastHit hit = new RaycastHit ();

		if(Physics.Raycast(transform.position, fwd, out hit, raycastDistance, layerMask)){
			Debug.Log ("hit object: " + hit.collider.gameObject.name);
		}
	}

	void OnDrawGizmos(){
		Vector3 fwd = GetComponentInChildren<Camera> ().transform.TransformDirection (Vector3.forward);

		Gizmos.DrawLine (transform.position, fwd * raycastDistance);
	}

}
