using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 direction = new Vector2(0, 1);

    [SerializeField] private int pullUses;
    [SerializeField] private int pushUses;
    [SerializeField] private int swapUses;
    [SerializeField] private int teleportUses;

    public AudioManager AudioManager;
    public Animator animator;

    private void Start()
    {
        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();
    }

    public bool ValidateMove(Vector2 directionToCheck)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, directionToCheck);

        GameObject otherObject = ray.collider.gameObject;

        if (Vector2.Distance(ray.point, transform.position) > 1)
        {
            animator.SetFloat("Y", direction.y);
            animator.SetFloat("X", direction.x);
            return true;
        }
        else if(otherObject.GetComponent<Box>() && otherObject.GetComponent<Box>().ValidateMove(directionToCheck))
        {
            GameManager.instance.Move(ray.collider.gameObject, directionToCheck);
            animator.SetFloat("Y", direction.y);
            animator.SetFloat("X", direction.x);
            return true;
        }

        return false;
    }

    // Pull
    public void Pull()
    {
        //Check if pull can be used, stop otherwise.
        if(pullUses < 1)
        {
            return;
        }
        pullUses--;

        //Play pull sound
        AudioManager.playConditional(4, false);

        //Variable that keeps track of how many blocks have been pulled
        int blocksPulled = 0;

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
        //Check if push can be used, stop otherwise.
        if (pushUses < 1)
        {
            return;
        }
        pushUses--;

        //Play push sound
        AudioManager.playConditional(3, false);
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

    // Swap
    public void Swap()
    {
        //Check if swap can be used, stop otherwise.
        if (swapUses < 1)
        {
            return;
        }
        swapUses--;

        // Checks if there is a box in front of the player
        if (Physics2D.Raycast(transform.position, direction).collider.gameObject.GetComponent<Box>())
        {
            Vector3 currentPosition = transform.position;
            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);
            GameObject otherObject = ray.collider.gameObject;

            // Sets the player's position to the box's 
            // And the box's to the players
            transform.position = otherObject.transform.position;
            otherObject.transform.position = currentPosition;
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }

    public void Teleport()
    {
        //Check if teleport can be used, stop otherwise.
        if (teleportUses < 1)
        {
            return;
        }
        teleportUses--;
        if (ValidateTeleport())
        {
            GameManager.instance.Move(gameObject, direction * 2);
        }
    }

    public bool ValidateTeleport()
    {
        //moveDistance accounts for teleport
        Vector2 teleportTile = (Vector2)transform.position + (direction * 2);

        RaycastHit2D ray = Physics2D.Raycast(teleportTile, direction);

        if (Vector2.Distance(ray.point, teleportTile) > 0)
        {
            return true;
        }

        return false;
    }
}
