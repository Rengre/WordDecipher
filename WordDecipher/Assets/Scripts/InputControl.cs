/*
 * This class implements methods used by input field and hint button
 * Ta klasa implementuje metody używane przez pole wprowadzania i przycisk podpowiedzi
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControl : MonoBehaviour
{
    [SerializeField] private InputField input;//represents field where user writes his answer
    [SerializeField] private Text text;// represents a text field with an encrypted word
    public GameObject nextLevel;//represents button NEXTLEVEL
    public GameObject quitPanel;//represents panel activated when the user wins the game
    public GameObject hintPanel;//represents panel with hint
    public GameObject imageHint;//represents image object in panel with hint
    public GameObject imageAlfabet;//represents image object in panel with hint
    public Text texthint;//represents text object in panel with hint
    public AudioSource music;//represents music activated when the user wins the game

    public void GetInput(string answer)//method used by input field
    {
        if (answer != text.GetComponent<GenarateText>().word) //check that user set wrong answer
        {
            input.text = null;
            input.placeholder.GetComponent<Text>().text = "Próbuj dalej";
        }else
        {

            if (text.GetComponent<GenarateText>().level <6)
            {
                input.text = null;
                input.placeholder.GetComponent<Text>().text = "Brawo!!";
                nextLevel.SetActive(true);
            }
            else 
            { 
                text.text = "Gratulacje !!";
                nextLevel.SetActive(false);
                quitPanel.SetActive(true);
                music.Play();
                
            }
           
        }
    }
    public void Hint()//method that sets visibility of panel with hint
    {
        hintPanel.SetActive(true);
        if (text.GetComponent<GenarateText>().caeserGame)
        {
            texthint.text = "Szyfr podstawieniowy\n Każda litera tekstu została zastępiona przez inną literę, oddaloną od niej o stałą liczbę pozycji w alfabecie";
            imageAlfabet.SetActive(true);
            imageHint.SetActive(true);
        }
        if (text.GetComponent<GenarateText>().shiftGame)
        {
            texthint.text = "Szyfr przestawieniowy \n Litery w zaszyfrowanym słowie zostały poprzestawiane. \n Sąsiadujące litery zamieniły się miejscami.  ";
            imageAlfabet.SetActive(false);
            imageHint.SetActive(false);
        }
    } 
    public void ExitHint()//method that closes panel with hint
    {
        hintPanel.SetActive(false);
    }

}
