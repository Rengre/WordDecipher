using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaeserCipherControl : MonoBehaviour
{
    public Text encryptedTextField;
    string cipherWord;
    public bool caeserGameIsChosen = false;

    public void SetCaeserCipherWord(string wordToEncrypte,int actualLevel)//method which use substitution cipher to encrypted word
    {
        cipherWord = "";
        foreach (char letter in wordToEncrypte)
        {
            cipherWord += (char)(((letter - 94+actualLevel) % 26) + 97); //each letter is replaced by a letter located three places from it in ASCII code
        }
        encryptedTextField.text = cipherWord;
    }
    public void CeaserCipherButtonIsClicked()//method which is used when CaeserCipher Button is clicked
    {
        caeserGameIsChosen = true;
        string word = encryptedTextField.GetComponent<GenarateText>().GetRandomWordFromFile("Assets/Scripts/Wyrazy4.txt");
        SetCaeserCipherWord(word,0);
    }
}
