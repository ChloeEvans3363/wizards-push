using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Player player;
    [SerializeField] private TextMeshProUGUI text;
    //private int[] spellUses = new int[3];

    // used for the swap highlight. Saves the box so it isn't stuck as green after swapping
    private GameObject swapBox;

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

    /// <summary>
    /// int i is the spell index, wil return the uses for that spell index
    /// 1-pull
    /// 2-push
    /// 3-tele
    /// 4-swap
    /// </summary>
    /// <param name="i"></param>
    public int GetUses(int i)
    {
        switch (i)
        {
            case 1:
                return player.PullUses;
                break;

            case 2:
                return player.PushUses;
                break;

            case 3:
                return player.TeleportUses;
                break;

            case 4:
                return player.SwapUses;
                break;
            default:
                return 0;
                break;
        }
    }

    // Highlights the boxes the player is able to pull when they hover over the pull spell
    public void PullHighlight()
    {
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }
    }

    // Removes the box highlights when the player is no longer hovering over the pull
    public void PullExit()
    {
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
        }
    }

    // Highlights the boxes the player is able to push when they hover over the push spell
    public void PushHighlight()
    {
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }
    }

    // Removes the box highlights when the player is no longer hovering over the push
    public void PushExit()
    {
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, -1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, -1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(0, 1)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(0, 1)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(-1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(-1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
        }

        if (Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>() && Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ValidateMove(new Vector2(1, 0)))
        {
            Physics2D.Raycast(player.transform.position, new Vector2(1, 0)).collider.gameObject.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
        }
    }

    // Highlights the boxes the player is able to push when they hover over the swap spell
    public void SwapHighlight()
    {
        if (Physics2D.Raycast(player.transform.position, player.GetDirection()).collider.gameObject.GetComponent<Box>())
        {
            swapBox = Physics2D.Raycast(player.transform.position, player.GetDirection()).collider.gameObject;
            swapBox.GetComponent<Box>().ChangeColor(Color.green);
            player.stop = true;
        }
    }

    //Removes the box highlights when the player is no longer hovering over the swap
    public void SwapExit()
    {
        if(swapBox != null)
        {
            swapBox.GetComponent<Box>().ChangeColor(Color.white);
            player.stop = false;
            swapBox = null;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = $"Pull: {player.PullUses}\nPush: {player.PushUses}\nTeleport: { player.TeleportUses}\nSwap: {player.SwapUses}";


  
    }
}
