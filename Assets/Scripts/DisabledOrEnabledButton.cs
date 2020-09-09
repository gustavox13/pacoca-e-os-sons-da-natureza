using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisabledOrEnabledButton : MonoBehaviour
{
    [SerializeField]
    private Button myButton;

    public void EnableButton()
    {
        myButton.interactable = true;
    }

    public void DisableButton()
    {
        myButton.interactable = false;
    }

}
