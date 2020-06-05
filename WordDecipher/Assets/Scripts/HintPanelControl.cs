using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintPanelControl : MonoBehaviour
{
    public Text texthint;
    public GameObject hintPanel;
    public GameObject imageHintForCaeserGame;
    public GameObject imageAlfabetForCaeserGame;
    public GameObject caeserCipherController;

    public void Hint()//method that sets visibility of panel with hint
    {
        hintPanel.SetActive(true);
        bool caeserGameSelection = caeserCipherController.GetComponent<CaeserCipherControl>().caeserGameIsChosen;
        RespondToGameType(caeserGameSelection);

    }
    private void RespondToGameType(bool caeserGame)
    {
        imageAlfabetForCaeserGame.SetActive(caeserGame);
        imageHintForCaeserGame.SetActive(caeserGame);
        if (caeserGame)
            texthint.text = "Szyfr podstawieniowy\n Każda litera tekstu została zastępiona przez inną literę, oddaloną od niej o stałą liczbę pozycji w alfabecie";
        else
            texthint.text = "Szyfr przestawieniowy \n Litery w zaszyfrowanym słowie zostały poprzestawiane. \n Spróbuj odgadnąć słowo.  ";
    }
    public void ExitHint()//method that closes panel with hint
    {
        hintPanel.SetActive(false);
    }
}
