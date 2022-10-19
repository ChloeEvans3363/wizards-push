using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        MovementKeys();
        Tailsmans();
    }

    public void MovementKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = new Vector2(-1, 0);
            if (player.ValidateMove(direction))
            {
                MovePlayer();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = new Vector2(0, 1);
            if (player.ValidateMove(direction))
            {
                MovePlayer();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = new Vector2(1, 0);
            if (player.ValidateMove(direction))
            {
                MovePlayer();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = new Vector2(0, -1);
            if (player.ValidateMove(direction))
            {
                MovePlayer();
            }
        }
    }

    public void Tailsmans()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.Pull();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.Push();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.Teleport();
        }
    }

    //helper methods
    public void MovePlayer()
    {
        GameManager.instance.Move(player.gameObject, direction);
        player.SetDirection(direction);
    }
}
