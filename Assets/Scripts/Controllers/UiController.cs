using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
 


    [SerializeField] private TextMeshPro coinValues;
    [SerializeField] private GameObject winUi;
    [SerializeField] private TextMeshProUGUI loseTextScores;

    [SerializeField] private GameObject loseUi;

    [SerializeField] private TextMeshProUGUI winTextScores;
    public void drawCoinValue(int val) {

        coinValues.text =  val.ToString();
    }

    public void losGame()
    {
        loseTextScores.text = coinValues.text;

        coinValues.gameObject.SetActive(false);

        loseUi.SetActive(true);

    }
    public void winGame() {

        winTextScores.text = coinValues.text;
        coinValues.gameObject.SetActive(false);
        winUi.SetActive(true);
    
    }

    public void gameRestart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}
