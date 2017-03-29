using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class SpriteFlowAnimation : MonoBehaviour {
    public float scrollSpeed = 0.5f;
    public string sortingLayerName;
    public int sortingOrder = 1;
    public float textureScale = 1;

    Renderer rend;

	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	void Update () {
        rend.sortingLayerName = sortingLayerName;
        rend.sortingOrder = sortingOrder;
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(0, offset);
        var ls = transform.localScale;
        rend.material.mainTextureScale = new Vector2(ls.x, ls.y) * textureScale;
    }
}
