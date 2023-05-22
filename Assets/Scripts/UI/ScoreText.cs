using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text text; 
    
    void Update()
    {
        text.text = EnemySpawner.Instance.GetScore().ToString();
    }
}
