using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        MovementKeys();
    }

    public void MovementKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameManager.instance.Move(player, new Vector2(-1, 0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameManager.instance.Move(player, new Vector2(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameManager.instance.Move(player, new Vector2(1, 0));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameManager.instance.Move(player, new Vector2(0, -1));
        }
    }
}
