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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(GameObject objectToMove, Vector2 direction)
    {
        objectToMove.transform.Translate(direction);
        objectToMove.GetComponent<Direction>().SetDirection(direction);
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
}
