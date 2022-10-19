using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 direction = new Vector2(0, 1);

    public AudioManager AudioManager;
    public bool ValidateMove(Vector2 directionToCheck)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, directionToCheck);

        GameObject otherObject = ray.collider.gameObject;

        if (Vector2.Distance(ray.point, transform.position) > 1 || ray.collider.gameObject.GetComponent<FinishPoint>())
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
        //Play push sound
        AudioManager.playConditional(3, false);

        // Moves the block down if the player is under the block
        if (Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            // Checks if the block is moved it won't go on top of the player
            RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(0, 1));
            GameObject otherObject = ray.collider.gameObject;

            if (otherObject.transform.position.y - 1 != transform.position.y)
                GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(0, 1)).collider.gameObject, new Vector2(0, -1));
        }

        // Moves the block up if the player is above the block
        if (Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            // Checks if the block is moved it won't go on top of the player
            RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(0, -1));
            GameObject otherObject = ray.collider.gameObject;

            if (otherObject.transform.position.y + 1 != transform.position.y)
                GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(0, -1)).collider.gameObject, new Vector2(0, 1));
        }

        // Moves the block right if the player is to the right of the block
        if (Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            // Checks if the block is moved it won't go on top of the player
            RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(-1, 0));
            GameObject otherObject = ray.collider.gameObject;

            if (otherObject.transform.position.x + 1 != transform.position.x)
                GameManager.instance.Move(Physics2D.Raycast(transform.position, new Vector2(-1, 0)).collider.gameObject, new Vector2(1, 0));
        }

        // Moves the block left if the player is to the left of the block
        if (Physics2D.Raycast(transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            // Checks if the block is moved it won't go on top of the player
            RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(1, 0));
            GameObject otherObject = ray.collider.gameObject;

            if (otherObject.transform.position.x - 1 != transform.position.x)
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
