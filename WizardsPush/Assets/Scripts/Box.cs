using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public bool ValidateMove(Vector2 direction)
    {
        Vector2 pos = transform.position;
        RaycastHit2D ray = Physics2D.Raycast(pos + direction, direction);

        if (Vector2.Distance(ray.point, transform.position) > 1 || ray.collider.gameObject.GetComponent<FinishPoint>())
        {
            return true;
        }

        return false;
    }
}
