using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public UI_Manager UIman;
    public Sprite[] textures;

    //spell index
    public int spellDex;

    Image m_pic;
    int uses;

    // Start is called before the first frame update
    void Start()
    {
        uses = UIman.GetUses(spellDex);
        //Debug.Log(uses);
        m_pic = GetComponent<Image>();
        m_pic.sprite = textures[uses];
    }

    // Update is called once per frame
    void Update()
    {
        uses = UIman.GetUses(spellDex);
        //Debug.Log(uses);
        m_pic.sprite = textures[uses];
    }
}
