using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject[] boxes;
    // Start is called before the first frame update
    void Start()
    {
        if(boxes.Length == 0)
        {
            boxes = GameObject.FindGameObjectsWithTag("Box");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        pull();
    }

    // Push
    public void pull()
    {
        foreach(GameObject box in boxes)
        {
            if(box.transform.position.x == transform.position.x)
            {
                if(box.transform.position.y < transform.position.y)
                {
                    
                }
                else
                {

                }
            }

            else if(box.transform.position.y == transform.position.y)
            {

            }
        }
    }

    public void push()
    {

    }
}
