using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Vector3 originalPos;

    void Awake() {
        originalPos = transform.position;
    }
    void OnTriggerEnter2D(Collider2D c) {
        if (c.name == "PlayerCharacter") {
            print("TODO: enemy collision event?");
            Destroy(gameObject);
        }
    }

    void Update() {
        transform.position = originalPos + Vector3.right * Mathf.Sin(Time.time);
    }
}
