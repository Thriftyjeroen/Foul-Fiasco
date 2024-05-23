using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // public variable for scrolling speed
    [SerializeField] float scrollSpeed = 1;
    // Private variable to keep track of the texture offset
    private float offset;
    // Private variable to store the material of the renderer
    private Material mat;

    private void Start()
    {
        // Get the material component from the renderer attached to the same GameObject
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Increment the offset based on the time passed since the last frame, scaled by scrollSpeed
        offset += (Time.deltaTime * scrollSpeed) / 10;

        // Update the texture offset of the material to create a scrolling effect
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
