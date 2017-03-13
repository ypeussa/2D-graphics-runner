using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public bool debug;
    public float testingScrollSpeed;
    [HideInInspector]
    public float smoothedHorizontalSpeed;

    public float runSpeed;
    public float jumpSpeed;
    public LayerMask jumpableObjects;
    public float playerGravity;

    Rigidbody2D rb;
    Text debugText;
    Collider2D col;

    float[] xSpeeds = new float[5];
    int xSpeedsIndex;

    bool jumped;

	void Awake() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        debugText = GameObject.Find("DebugText").GetComponent<Text>();
        SetDebugStuff();
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            debug = !debug;
            SetDebugStuff();
        }
        if (debug)
            return;
        if (Input.GetButtonDown("Jump")) {
            jumped = true;
        }
    }

    void FixedUpdate() {
        if (debug) {
            var xSpeed = Input.GetAxis("Horizontal") * testingScrollSpeed;
            rb.velocity = Vector3.right * xSpeed;
            UpdateSmoothedSpeed(xSpeed);
            return;
        }
        var v = rb.velocity;
        if (jumped) {
            jumped = false;
            bool allowedToJump = null != Physics2D.OverlapCircle(transform.position + Vector3.down * 0.8f, 0.2f, jumpableObjects);
            if (allowedToJump)
                v.y = jumpSpeed;
        }
        v.x = runSpeed;
        rb.velocity = v;
        UpdateSmoothedSpeed(v.x);
    }

    void SetDebugStuff() {
        col.isTrigger = debug;
        rb.gravityScale = debug ? 0f : playerGravity;
        debugText.text = debug ?
            "Free float mode - glide with arrow keys, X to switch" :
            "Runner mode - space to jump, X to switch";
    }
    void UpdateSmoothedSpeed(float newXspeed) {
        xSpeeds[xSpeedsIndex++] = newXspeed;
        xSpeedsIndex %= xSpeeds.Length;
        var avg = xSpeeds.Sum();
        avg /= xSpeeds.Length;
        smoothedHorizontalSpeed = avg;
    }
}
