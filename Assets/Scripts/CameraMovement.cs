using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Transform player;
	private Vector3 cameraPos;
	private Vector3 result;

	public float smoothTime = 0.1f; // time for dampen
	public bool cameraFollowX = true; // camera follows on horizontal
	public Vector2 velocity; // speed of camera movement
	private Transform thisTransform; // camera Transform

	// Use this for initialization
	void Start () {
		thisTransform = transform;
		velocity.x = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.Find ("Cubito").transform;
		thisTransform.position = new Vector3(Mathf.SmoothDamp(thisTransform.position.x, player.transform.position.x, ref velocity.x, smoothTime), thisTransform.position.y, thisTransform.position.z);

	}
}
