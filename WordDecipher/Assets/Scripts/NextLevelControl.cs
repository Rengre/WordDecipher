using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelControl : MonoBehaviour
{
    public Text encryptedWord;// represents a text field with an encrypted word
    public InputField inputFieldWithAnswer;//represents field where user writes his answer
    public Text nextLevelLabel;//reprents text that show which level is
    public GameObject caeserCipherController;
    public GameObject transpositionCipherController;
    public GameObject nextLevelButton;
    public int level = 0;//represents a number of level
    public int maxLevel = 6;

    public void NextLevel()//method used by next level button
    {

        level++;
        if (level <= maxLevel)
        {
            int c = 4 + level;
            string path = "Assets/Scripts/Wyrazy" + c + ".txt";//choses file to level
            string word = encryptedWord.GetComponent<GenarateText>().GetRandomWordFromFile(path);

            if (caeserCipherController.GetComponent<CaeserCipherControl>().caeserGameIsChosen)
                caeserCipherController.GetComponent<CaeserCipherControl>().SetCaeserCipherWord(word,level);
            else
             transpositionCipherController.GetComponent<TranspositionCipherControl>().SetTranspositionCipherWord(word,level);

            nextLevelLabel.text = "Poziom " + level;
            inputFieldWithAnswer.text = null;
            inputFieldWithAnswer.placeholder.GetComponent<Text>().text = "Wpisz tekst tutaj";
            nextLevelButton.SetActive(false);
        }
    }
}
