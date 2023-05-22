using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{
    private GameObject hand;

    private void Start(){
    
        hand = transform.GetChild(0).gameObject;
    }
    
    public void Hide()
    {
        hand.SetActive(false);
    }

    public void Show()
    {
        hand.SetActive(true);
    }
}
