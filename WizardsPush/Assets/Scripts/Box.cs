using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (GetComponent<SpriteRenderer>() != null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

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

        if (Vector2.Distance(ray.point, transform.position) > 1 || ray.collider.gameObject.GetComponent<FinishPoint>() || ray.collider.gameObject.tag == "Spike")
        {
            return true;
        }

        return false;
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
