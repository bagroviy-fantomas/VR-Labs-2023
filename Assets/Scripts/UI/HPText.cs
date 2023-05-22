using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPText : MonoBehaviour
{
    [SerializeField] private TMP_Text text; 
    
    void Update()
    {
        text.text = Player.Instance.GetCurrentHP().ToString();
    }
}
