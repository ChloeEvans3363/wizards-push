using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Direction direction = otherCollider.gameObject.GetComponent<Direction>();
        if (direction)
        {
            GameManager.instance.Move(gameObject, direction.GetDirection());
        }
    }
}
