using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Player player;
    [SerializeField] private TextMeshProUGUI text;

    public void usePull()
    {
        player.Pull();
    }

    public void usePush()
    {
        player.Push();
    }

    public void useTele()
    {
        player.Teleport();
    }

    public void useSwap()
    {
        player.Swap();
    }

    // Highlights the boxes the player is able to pull when they hover over the pull spell
    public void PullHighlight()
    {
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }
    }

    // Removes the box highlights when the player is no longer hovering over the pull
    public void PullExit()
    {
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }
    }

    // Highlights the boxes the player is able to push when they hover over the push spell
    public void PushHighlight()
    {
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }
    }

    // Removes the box highlights when the player is no longer hovering over the push
    public void PushExit()
    {
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }
    }

    // Highlights the boxes the player is able to push when they hover over the swap spell
    public void SwapHighlight()
    {
        if (Physics2D.Raycast(player.transform.position, player.GetDirection()).collider.gameObject.GetComponent<Box>())
        {
            Physics2D.Raycast(player.transform.position, player.GetDirection()).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
        }
    }

    //Removes the box highlights when the player is no longer hovering over the swap
    public void SwapExit()
    {
        if (Physics2D.Raycast(player.transform.position, player.GetDirection()).collider.gameObject.GetComponent<Box>())
        {
            Physics2D.Raycast(player.transform.position, player.GetDirection()).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Pull: {player.PullUses}\nPush: {player.PushUses}\nTeleport: { player.TeleportUses}\nSwap: {player.SwapUses}";
    }
}
