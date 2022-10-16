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

    public bool ValidateMove(Vector2 direction)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);

        GameObject otherObject = ray.collider.gameObject;

        if (Vector2.Distance(ray.point, transform.position) > 1)
        {
            return true;
        }
        else if(otherObject.GetComponent<Box>() && otherObject.GetComponent<Box>().ValidateMove(direction))
        {
            GameManager.instance.Move(ray.collider.gameObject, direction);
            return true;
        }

        return false;
    }

    // Pull
    public void Pull()
    {
        // Checks each box on the level
        foreach(GameObject box in boxes)
        {
            // If the box has the same x position then the y position will change to move the box closer
            if(box.transform.position.x == transform.position.x)
            {
                // depending on if the box is to the right of the left of the player the box will move the direction to get closer
                if (box.transform.position.y < transform.position.y - 1)
                {
                    box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y + 1, box.transform.position.z);
                }
                else if (box.transform.position.y > transform.position.y + 1)
                {
                    box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y - 1, box.transform.position.z);
                }
            }

            // If the box has the same y position then the x position will change to move the box closer
            else if (box.transform.position.y == transform.position.y)
            {
                // depending on if the box is above or below the player the box will move the direction to get closer
                if (box.transform.position.x < transform.position.x - 1)
                {
                    box.transform.position = new Vector3(box.transform.position.x + 1, box.transform.position.y, box.transform.position.z);
                }
                else if(box.transform.position.x > transform.position.x + 1)
                {
                    box.transform.position = new Vector3(box.transform.position.x - 1, box.transform.position.y, box.transform.position.z);
                }
            }
        }
    }

    // Push
    public void Push()
    {
        // Checks each box on the level
        foreach (GameObject box in boxes)
        {
            // If the box has the same x position then the y position will change to move the box further away
            if (box.transform.position.x == transform.position.x)
            {
                // depending on if the box is to the right of the left of the player the box will move the direction to get further
                if (box.transform.position.y < transform.position.y)
                {
                    box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y - 1, box.transform.position.z);
                }
                else if (box.transform.position.y > transform.position.y)
                {
                    box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y + 1, box.transform.position.z);
                }
            }
            // If the box has the same y position then the x position will change to move the box further away
            else if (box.transform.position.y == transform.position.y)
            {
                // depending on if the box is above or below the player the box will move the direction to get further
                if (box.transform.position.x < transform.position.x)
                {
                    box.transform.position = new Vector3(box.transform.position.x - 1, box.transform.position.y, box.transform.position.z);
                }
                else if (box.transform.position.x > transform.position.x)
                {
                    box.transform.position = new Vector3(box.transform.position.x + 1, box.transform.position.y, box.transform.position.z);
                }
            }
        }
    }
}
