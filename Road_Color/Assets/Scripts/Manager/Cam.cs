using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
	private Transform target;
	private Vector3 offset;

    void Start()
    {
		target = FindObjectOfType<BallHandler>().transform;

		offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
		transform.position = Vector3.Lerp(transform.position, newPos, 10 * Time.deltaTime);
    }
}
