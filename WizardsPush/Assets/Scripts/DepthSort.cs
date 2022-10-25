//Author: Egan Frelich
//Sets depth sorting order.
//The general functionality can be moved to other scripts if we want.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSort : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer.sortingOrder = Mathf.FloorToInt(-transform.position.y);
    }
}
