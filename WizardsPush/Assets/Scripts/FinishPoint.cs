using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private bool finished = false;
    [SerializeField] private Sprite unfinishedSprite;
    [SerializeField] private Sprite finishedSprite;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Box>() && !finished)
        {
            finished = true;
            GameManager.instance.FinishPointReached();
            gameObject.GetComponent<SpriteRenderer>().sprite = finishedSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Box>() && finished)
        {
            finished = false;
            GameManager.instance.FinishPointVoided();
            gameObject.GetComponent<SpriteRenderer>().sprite = unfinishedSprite;
        }
    }
}
