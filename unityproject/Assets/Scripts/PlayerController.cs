using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public bool debug;
    public float testingScrollSpeed;

    public float runSpeed;
    public float jumpSpeed;
    Rigidbody2D rb;

    bool jumped;

	void Awake() {
        rb = GetComponent<Rigidbody2D>();
	}

    void Update() {
        if (debug) {
            transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * testingScrollSpeed;
            return;
        }
        if (Input.GetButtonDown("Jump")) {
            jumped = true;
        }
    }

    void FixedUpdate() {
        var v = rb.velocity;
        // TODO: allowed to jump?
        if (jumped) {
            v.y = jumpSpeed;
            jumped = false;
        }
        v.x = runSpeed;
        rb.velocity = v;
    }
}
