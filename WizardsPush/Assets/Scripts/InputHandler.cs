using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector2 direction;
    private bool locked;

    private void Start()
    {
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (locked)
        {
            TurnDirection();
        }
        else
        {
            MovementKeys();
        }
        Tailsmans();
        LockPlayerMovement();
    }

    public void MovementKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (!player.stop)
            {
                direction = new Vector2(-1, 0);
                MovePlayer();
                player.SetAnimation();
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (!player.stop)
            {
                direction = new Vector2(0, 1);
                MovePlayer();
                player.SetAnimation();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (!player.stop)
            {
                direction = new Vector2(1, 0);
                MovePlayer();
                player.SetAnimation();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (!player.stop)
            {
                direction = new Vector2(0, -1);
                MovePlayer();
                player.SetAnimation();
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

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.Swap();
        }
    }

    public void TurnDirection()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (!player.stop)
            {
                direction = new Vector2(-1, 0);
                player.SetDirection(direction);
                player.SetAnimation();
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (!player.stop)
            {
                direction = new Vector2(0, 1);
                player.SetDirection(direction);
                player.SetAnimation();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (!player.stop)
            {
                direction = new Vector2(1, 0);
                player.SetDirection(direction);
                player.SetAnimation();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (!player.stop)
            {
                direction = new Vector2(0, -1);
                player.SetDirection(direction);
                player.SetAnimation();
            }
        }
    }

    public void LockPlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            locked = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            locked = false;
        }
    }

    //helper methods
    public void MovePlayer()
    {
        player.SetDirection(direction);
        if (player.ValidateMove(direction))
        {
            GameManager.instance.Move(player.gameObject, direction);
        }
    }
}
