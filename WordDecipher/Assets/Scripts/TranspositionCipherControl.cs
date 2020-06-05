using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranspositionCipherControl : MonoBehaviour
{
    public Text encryptedTextField;// represents a text field with an encrypted word
    char[] arrayWord;//encrypted word in char array

    public void SetTranspositionCipherWord(string word,int actualLevel)//method which use transposition cipher to encrypted word
    {
        arrayWord = word.ToCharArray();
        for (int i = 0; i < arrayWord.Length - 1-actualLevel; i += 2)
        {
            char temp = arrayWord[i];
            arrayWord[i] = arrayWord[i + 1+actualLevel]; // swapped letter to encrypte word
            arrayWord[i + 1+actualLevel] = temp;
        }
        encryptedTextField.text = new string(arrayWord);
    }

    public void TranspositionCipherButtonIsClicked()//method which is used when ShiftCipher Button is clicked
    {
        string word = encryptedTextField.GetComponent<GenarateText>().GetRandomWordFromFile("Assets/Scripts/Wyrazy4.txt");
        SetTranspositionCipherWord(word,0);
    }
}
