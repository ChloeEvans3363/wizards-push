using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 direction = new Vector2(0, 1);

    public AudioManager AudioManager;

    public bool ValidateMove(Vector2 direction)
    public bool ValidateMove(Vector2 directionToCheck)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, directionToCheck);

        GameObject otherObject = ray.collider.gameObject;

        if (Vector2.Distance(ray.point, transform.position) > 1)
        {
            return true;
        }
        else if(otherObject.GetComponent<Box>() && otherObject.GetComponent<Box>().ValidateMove(directionToCheck))
        {
            GameManager.instance.Move(ray.collider.gameObject, directionToCheck);
            return true;
        }

        return false;
    }

    // Pull
    public void Pull()
    {
        //Play pull sound
        AudioManager.playConditional(4, false);

        // Checks each box on the level
        foreach(GameObject box in GameManager.instance.GetBoxes())
        {
            // If the box has the same x position then the y position will change to move the box closer
            if(box.transform.position.x == transform.position.x)
            {
                // depending on if the box is to the right of the left of the player the box will move the direction to get closer
                if (box.transform.position.y < transform.position.y - 1 && box.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
                {
                    GameManager.instance.Move(box, new Vector2(0, 1));

                }
                else if (box.transform.position.y > transform.position.y + 1 && box.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
                {
                    GameManager.instance.Move(box, new Vector2(0, -1));

                }
            }

            // If the box has the same y position then the x position will change to move the box closer
            else if (box.transform.position.y == transform.position.y)
            {
                // depending on if the box is above or below the player the box will move the direction to get closer
                if (box.transform.position.x < transform.position.x - 1 && box.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
                {
                    GameManager.instance.Move(box, new Vector2(1, 0));

                }
                else if(box.transform.position.x > transform.position.x + 1 && box.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
                {
                    GameManager.instance.Move(box, new Vector2(-1, 0));

                }
            }
        }
    }

    // Test Pull rework. It works but the box will get pulled on top of the player
    public void test()
    {
        //Play push sound
        AudioManager.playConditional(3, false);

        // Checks each box on the level
        foreach (GameObject box in GameManager.instance.GetBoxes())
        if (Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0,-1)))
        {
            GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject, new Vector2(0, -1));
        }

        if (Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            if (Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.transform.position.y + 1 != transform.position.y)
                GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject, new Vector2(0, 1));
        }

        if (Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            if (Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.transform.position.x + 1 != transform.position.x)
                GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject, new Vector2(1, 0));
        }

        if (Physics2D.Raycast(transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            if (Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.transform.position.x - 1 != transform.position.x)
                GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(1, 0)).collider.gameObject, new Vector2(-1, 0));

        }
    }

    // Push
    public void Push()
    {
        // Moves the block up if the player is under the block
        if (Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject, new Vector2(0, 1));
        }

        // Moves the block down if the player is above the block
        if (Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject, new Vector2(0, -1));
        }

        // Moves the block left if the player is to the right of the block
        if (Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject, new Vector2(-1, 0));
        }

        // Moves the block right if the player is to the left of the block
        if (Physics2D.Raycast(transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(1, 0)).collider.gameObject, new Vector2(1, 0));
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    public void Teleport()
    {
        if (ValidateTeleport())
        {
            GameManager.instance.Move(gameObject, direction * 2);
        }
    }

    public bool ValidateTeleport()
    {
        //moveDistance accounts for teleport
        RaycastHit2D ray = Physics2D.Raycast((Vector2) transform.position + (direction * 2), direction);

        GameObject otherObject = ray.collider.gameObject;

        if (Vector2.Distance(ray.point, transform.position) > 0)
        {
            return true;
        }

        return false;
    }
}
