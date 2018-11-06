using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// USAGE: put this on the GameObject that has the MainCamera as the child
// INTENT: camera to follow player, player can also rotate camera
public class CameraController_JZ : MonoBehaviour
{

	public float lookSpeed = 10f;
	public GameObject ballPos;

	public float rotateDistance = 10f;

	public Vector3 relativeDistance = Vector3.zero;

	void Start()
	{
		relativeDistance = transform.position - ballPos.transform.position;
	}

	void LateUpdate () {
		
		// CAMERA POSITION:
		// set camera to ball's position with an offset

		//Vector3 offset = new Vector3(0, 1f, -10f); // cam will always stay this distance from ball
		//transform.position = ballPos.transform.position + offset; // applying new offset pos to camera
		
		
		// CAMERA ROTATION:
		
		//transform.LookAt(ballPos.transform.position);
		// when Q is held, camera will rotate left
		if (Input.GetKey(KeyCode.Q))
		{
			//transform.Rotate( 0f, -lookSpeed, 0f);
			RotateAroundBall(Vector3.down);
			
		}
		else if (Input.GetKey((KeyCode.O))) // when O is held, camera will rotate right
		{
			RotateAroundBall(Vector3.up);
			//transform.Rotate( 0f, lookSpeed, 0f);
		}
	}

	void RotateAroundBall(Vector3 direction)
	{
		transform.position = ballPos.transform.position + relativeDistance;
		transform.RotateAround(ballPos.transform.position, direction, 20 * lookSpeed * Time.deltaTime);

		relativeDistance = transform.position - ballPos.transform.position;
	}
}
// set camera to ball with offset
// not child
// calculate ball, calculate camera, then calculate position of player with midpoint of the two
// cam = ball.position - ball.forward