using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwirlerAnimation : MonoBehaviour {
    public float rotateSpeed;
    public float floatHeight;
    Vector3 startingPosition;

    void Awake () {
        startingPosition = transform.position;
    }
	void Update () {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        transform.position = startingPosition + Vector3.up * Mathf.Sin(Time.time * 2) * floatHeight;
    }
}
