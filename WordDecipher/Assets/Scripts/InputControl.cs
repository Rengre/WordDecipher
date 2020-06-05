/*
 * This class implements methods used by input field 
 * Ta klasa implementuje metody używane przez pole wprowadzania
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControl : MonoBehaviour
{
    public InputField inputFieldWithAnswer;
    public Text encryptedWordField;
    public GameObject nextLevelButton;
    public GameObject nextLevelController;
    public GameObject endingPanel;//represents panel activated when the user wins the game
    public AudioSource winnerMusic;//represents music activated when the user wins the game

    public void GetInput(string answer)//method used by InputField
    {
        ReactToAnswer(answer);
        inputFieldWithAnswer.text = null;

    }
    private void ReactToAnswer(string answer)
    {
        int actualLevel = nextLevelController.GetComponent<NextLevelControl>().level;
        int maxLevel = nextLevelController.GetComponent<NextLevelControl>().maxLevel;
        string goodanswer = encryptedWordField.GetComponent<GenarateText>().word;

        if (answer == goodanswer )
        {
            if (actualLevel < maxLevel)
            {
                inputFieldWithAnswer.placeholder.GetComponent<Text>().text = "Brawo!!";
                nextLevelButton.SetActive(true);
            }
            else
            {
                encryptedWordField.text = "Gratulacje !!";
                nextLevelButton.SetActive(false);
                endingPanel.SetActive(true);
                winnerMusic.Play();
            }

        }
        else
            inputFieldWithAnswer.placeholder.GetComponent<Text>().text = "Próbuj dalej";
    }
}
