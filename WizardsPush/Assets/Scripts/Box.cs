using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        Direction direction = otherObject.GetComponent<Direction>();

        if (direction)
        {
            GameManager.instance.Move(gameObject, direction.GetDirection());
        }
    }
}
