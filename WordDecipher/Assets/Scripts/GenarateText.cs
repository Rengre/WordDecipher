using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GenarateText : MonoBehaviour
{
    public GameObject startScreenPanel;
    public string word;


    public string GetRandomWordFromFile(string path)
    {
        startScreenPanel.SetActive(false); //hide start screen panel
        string[] readText = File.ReadAllLines(path); //read words from file
        word = readText[Random.Range(0, readText.Length)]; //chose a random words from file
        return word;
    }
  
}
