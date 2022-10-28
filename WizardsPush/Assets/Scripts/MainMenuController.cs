using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject controls;

    public void ShowHideControls()
    {
        controls.SetActive(!controls.activeInHierarchy);
    }
}
