using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{

    public SceneChanger changer;
    private int currentLevel;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        changer = null;
    }

    public void ChangeLvlNum(int i)
    {
        currentLevel = i;
    }

    public void NextLevel()
    {
        if (FindObjectOfType<SceneChanger>() != null)
        {
            changer = FindObjectOfType<SceneChanger>();
        }
        if (changer != null)
        {
            currentLevel++;


            changer.ChangeScene(currentLevel.ToString());

        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
