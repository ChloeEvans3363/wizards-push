using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] private Vector2 direction = new Vector2(0, 1);

    public Vector2 GetDirection()
    {
        return direction;
    }

    public void SetDirection(Vector2 value)
    {
        direction = value;
    }
}
