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
            switch (currentLevel)
            {
                case 1:
                    changer.ChangeScene("1_OpeningLevel");
                    break;
                case 2:
                    changer.ChangeScene("2_NoSpell_2");
                    break;
                case 3:
                    changer.ChangeScene("3_NoSpell_3");
                    break;
                case 4:
                    changer.ChangeScene("4_Pull_Demo");
                    break;
                case 5:
                    changer.ChangeScene("5_Pull_intro");
                    break;
                case 6:
                    changer.ChangeScene("6_Pull_Advanced");
                    break;
                case 7:
                    changer.ChangeScene("7_Teleport");
                    break;
                case 8:
                    changer.ChangeScene("8_Swap");
                    break;
                case 9:
                    changer.ChangeScene("9_All");
                    break;
                case 10:
                    changer.ChangeScene("10_T_S");
                    break;
                case 11:
                    changer.ChangeScene("11_SingleSwap");
                    break;
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
