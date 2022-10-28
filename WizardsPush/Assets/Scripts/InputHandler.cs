using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector2 direction;
    [SerializeField] private string nextLevel = null;
    private bool keyboardLocked;
    private bool mouseLocked;

    private void Start()
    {
        keyboardLocked = false;
        mouseLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboardLocked)
        {
            TurnDirectionKeyboard();
        }
        else if (mouseLocked)
        {
            TurnDirectionMouse();
        }
        else
        {
            MovementKeys();
        }
        Tailsmans();
        MiscKeys();
        LockPlayerMovementKeyboard();
        LockPlayerMovementMouse();
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

    public void TurnDirectionKeyboard()
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

    public void TurnDirectionMouse()
    {
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x < player.transform.position.x - player.transform.lossyScale.x))
        {
            if (!player.stop)
            {
                direction = new Vector2(-1, 0);
                player.SetDirection(direction);
                player.SetAnimation();
            }

        }
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).y > player.transform.position.y + player.transform.lossyScale.y))
        {
            if (!player.stop)
            {
                direction = new Vector2(0, 1);
                player.SetDirection(direction);
                player.SetAnimation();
            }
        }
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x > player.transform.position.x + player.transform.lossyScale.x))
        {
            if (!player.stop)
            {
                direction = new Vector2(1, 0);
                player.SetDirection(direction);
                player.SetAnimation();
            }
        }
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).y < player.transform.position.y - player.transform.lossyScale.y))
        {
            if (!player.stop)
            {
                direction = new Vector2(0, -1);
                player.SetDirection(direction);
                player.SetAnimation();
            }
        }
    }

    public void LockPlayerMovementKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            keyboardLocked = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            keyboardLocked = false;
        }
    }

    private void LockPlayerMovementMouse()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseLocked = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            mouseLocked = false;
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

    public void MiscKeys()
    {
        //restart level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("0_LevelSelect");
        }

        //next level
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.GameWon() && nextLevel != null)
        {
            Debug.Log(nextLevel);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
