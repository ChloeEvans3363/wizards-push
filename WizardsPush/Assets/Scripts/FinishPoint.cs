using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private bool finished = false;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Box>() && !finished)
        {
            finished = true;
            GameManager.instance.FinishPointReached();
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Box>() && finished)
        {
            finished = false;
            GameManager.instance.FinishPointVoided();
        }
    }
}
