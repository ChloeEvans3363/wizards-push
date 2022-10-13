//Author: Egan Frelich, Who knows when
//This was made for a personal project but it'd be useful here
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectPositionRounder : MonoBehaviour
{
    public bool round = true;
    // Start is called before the first frame update
    void Start()
    {
        if(Application.isPlaying) {
            Destroy(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (round && !Application.isPlaying) {
            RoundPosition();
            //RoundSize();
        }
    }
    public void RoundPosition () {
        //Round to half units
        float newX = Mathf.Round(transform.position.x * 2f) * 0.5f;
        float newY = Mathf.Round(transform.position.y * 2f) * 0.5f;

        //I haven't properly tested this, but this should round to full units, 
        //plus a 0.5 offset for tiling reasons.
        //float newX = Mathf.Round(transform.position.x) + 0.5f;
        //float newY = Mathf.Round(transform.position.y) + 0.5f;
        //transform.position = new Vector2(newX, newY);
    }
    /*public void RoundSize () {
        float newX = Mathf.Round(transform.localScale.x);
        float newY = Mathf.Round(transform.localScale.y);
        transform.localScale = new Vector3(newX, newY, 1f);
    }*/
}
