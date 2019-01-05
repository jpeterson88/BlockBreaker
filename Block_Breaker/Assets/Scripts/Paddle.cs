using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	[SerializeField] private float screenWidthInUnits = 16f;
	[SerializeField] private float minX = 1f;
	[SerializeField] private float maxX = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mousePositionInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
		Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
		paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minX, maxX);
		transform.position = paddlePosition;
	}
}
