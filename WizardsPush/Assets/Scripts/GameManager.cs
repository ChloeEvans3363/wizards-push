using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioManager AudioManager;

    public void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject player;
    [SerializeField] private int finishPoints;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject[] boxes;
    [SerializeField] private bool gameWon = false;

    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>().PlayMusic();
        }

        finishPoints = GameObject.FindObjectsOfType<FinishPoint>().Length;
        boxes = GameObject.FindGameObjectsWithTag("Box");
    }

    public void Move(GameObject objectToMove, Vector2 vector)
    {
        objectToMove.transform.Translate(vector);
    }

    public void FinishPointReached()
    {
        //TargetDown sound cue
        AudioManager.playConditional(1, false);
        finishPoints--;
        if(finishPoints == 0)
        {
            winText.SetActive(true);
            gameWon = true;
           
        }
    }

    private void OnGUI()
    {
        if (gameWon)
        {
            if (GUI.Button(new Rect(380, 220, 200, 100), "Next Level"))
            {
                FindObjectOfType<Progression>().NextLevel();
            }
        }
    }

    public void FinishPointVoided()
    {
        //TargetUp sound cue
        AudioManager.playConditional(2, false);

        finishPoints++;
    }

    public GameObject[] GetBoxes()
    {
        return boxes;
    }

    public bool GameWon()
    {
        return gameWon;
    }
}
