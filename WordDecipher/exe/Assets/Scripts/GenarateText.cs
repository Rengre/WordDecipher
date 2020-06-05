/*
 * This class implements two methods that encrypt words and the method used by next level button
 * Ta klasa implementuje dwie metody szyfrujące słowa oraz metodę używaną przez przycisk następnego poziomu
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GenarateText : MonoBehaviour
{
    [SerializeField] private Text text;// represents a text field with an encrypted word
    public InputField input; //represents field where user writes his answer
    public GameObject startScreen; // represents a start panel
    public GameObject nextLevel; // represents a button NextLevel
    public Text nextLevelLabel;//reprents text that show which level is
    public bool caeserGame =false; // represents that user chosen  substitution cipher
    public  bool shiftGame =false;//represents that user chosen  transposition cipher
    public  string word; //a word that will encrypted
    string cipherWord="";//encrypted word
    char[] arrayWord;//encrypted word in char array
    int i;
    public int level = 0;//represents a number of level
    string path = "Assets/Scripts/Wyrazy4.txt";//path represents file with words

    public void CaeserCipher()//method which use substitution cipher to encrypted word
    {
        startScreen.SetActive(false);
        caeserGame= true;
        string[] readText = File.ReadAllLines(path); //read words from file
         word = readText[Random.Range(0, readText.Length)]; //chose a random words from file
        i = 0;
        foreach (char t in word)
        {
            cipherWord += (char)(((t - 94) % 26) + 97); //each letter is replaced by a letter located three places from it in ASCII code
            i++;
        }
        text.text = cipherWord;
    }

    public void ShiftCipher()//method which use transposition cipher to encrypted word
    {
        startScreen.SetActive(false);
        shiftGame = true;
        string[] readText = File.ReadAllLines(path);
        word = readText[Random.Range(0, readText.Length)];
        arrayWord = word.ToCharArray();
        for (int i= 0; i < arrayWord.Length-1; i += 2)
        {
            char temp = arrayWord[i];
            arrayWord[i] = arrayWord[i + 1]; //adjacent letters are swapped
            arrayWord[i + 1] = temp;
        }
        text.text = new string(arrayWord);
    }

    public void NextLevel()//method used by next level button
    {
        
        level++;
        if (level <= 6)
        {
            int c = 4 + level;
            path = "Assets/Scripts/Wyrazy" + c + ".txt";//choses file to level
            if (caeserGame)
            {
                cipherWord = "";
                CaeserCipher();
            }
            if (shiftGame) ShiftCipher();

            nextLevelLabel.text = "Poziom " + level;
            input.text = null;
            input.placeholder.GetComponent<Text>().text  = "Wpisz tekst tutaj";
        } 
       

    nextLevel.SetActive(false);

    }
  
}
