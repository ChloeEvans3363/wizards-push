using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject player;
    [SerializeField] private int finishPoints;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject[] boxes;

    public void Start()
    {
        finishPoints = GameObject.FindObjectsOfType<FinishPoint>().Length;
        boxes = GameObject.FindGameObjectsWithTag("Box");
    }

    public void Move(GameObject objectToMove, Vector2 direction)
    {
        objectToMove.transform.Translate(direction);
    }

    public void FinishPointReached()
    {
        finishPoints--;
        if(finishPoints == 0)
        {
            winText.SetActive(true);
        }
    }

    public void FinishPointVoided()
    {
        finishPoints++;
    }

    public GameObject[] GetBoxes()
    {
        return boxes;
    }
}
