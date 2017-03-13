using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;
    public float speedLookaheadFactor;
    public float smoothTime;

    PlayerController pc;
    Camera cam;
    Vector3 currentVelocity = Vector3.zero;
    Vector2 targetPosGizmo;

	void Awake () {
        cam = GetComponent<Camera>();
        if (!player)
            player = GameObject.Find("PlayerCharacter").transform;
        pc = player.GetComponent<PlayerController>();
	}

    void FixedUpdate() {
        var pos = transform.position;
        var targetPos = pos;
        targetPos.x = player.position.x;
        if (pc)
            targetPos.x += speedLookaheadFactor * pc.smoothedHorizontalSpeed;
        // TODO: clamp target to stay within screen?
        // var screenWidth = cam.aspect * cam.orthographicSize;
        transform.position = Vector3.SmoothDamp(pos, targetPos, ref currentVelocity, smoothTime);
        targetPosGizmo = targetPos;
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(targetPosGizmo, 1f);
    }
}
