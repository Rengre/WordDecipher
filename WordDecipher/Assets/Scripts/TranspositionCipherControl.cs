using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranspositionCipherControl : MonoBehaviour
{
    public Text encryptedTextField;
    char[] arrayWord;

    public void TranspositionCipherButtonIsClicked()//method which is used when ShiftCipher Button is clicked
    {
        string word = encryptedTextField.GetComponent<GenarateText>().GetRandomWordFromFile("Assets/Scripts/Wyrazy4.txt");
        SetTranspositionCipherWord(word, 0);
    }
    public void SetTranspositionCipherWord(string word,int currentLevel)//method which set encrypted word to TextField
    {
        arrayWord = word.ToCharArray();
        SwapLetter(currentLevel);
        encryptedTextField.text = new string(arrayWord);
    }

   private void SwapLetter(int currentLevel)//method which use transposition cipher to encrypted word
    {
        for (int i = 0; i < arrayWord.Length - 1 - currentLevel; i += 2)
        {
            char temp = arrayWord[i];
            arrayWord[i] = arrayWord[i + 1 + currentLevel]; // swapped letter to encrypte word
            arrayWord[i + 1 + currentLevel] = temp;
        }
    }
}
