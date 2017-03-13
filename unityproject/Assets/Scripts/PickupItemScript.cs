using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c) {
        if (c.name == "PlayerCharacter") {
            print("TODO: item pickup effect?");
            Destroy(gameObject);
        }
    }
}
