using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaeserCipherControl : MonoBehaviour
{
    public Text encryptedTextField;
    string cipherWord;
    public bool caeserGameIsChosen = false;

    public void CeaserCipherButtonIsClicked()//method which is used when CaeserCipher Button is clicked
    {
        caeserGameIsChosen = true;
        string word = encryptedTextField.GetComponent<GenarateText>().GetRandomWordFromFile("Assets/Scripts/Wyrazy4.txt");
        SetCaeserCipherWord(word, 0);
    }

    public void SetCaeserCipherWord(string wordToEncrypte,int currentLevel)//method which set encrypted word to TextField
    {
        cipherWord = "";
        ReplacedLetter(wordToEncrypte, currentLevel);
        encryptedTextField.text = cipherWord;
    }
   
    private void ReplacedLetter(string wordToEncrypte, int currentLevel)//method which use substitution cipher to encrypted word
    {
        foreach (char letter in wordToEncrypte)
        {
            cipherWord += (char)(((letter - 94 + currentLevel) % 26) + 97); //each letter is replaced by a letter located in ASCII code at distance =3+number of current level 
        }
    }
}
