using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int numCoins;

    [SerializeField] private int numSpikes;

    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private GameObject SpikePrefab;


    [SerializeField] private UiController uiController;



    public static GameManager Instance;




    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else {   
            Instance = this;          
        }

    }


    private void Start()
    {

        onRestartTimeScaleDef();
        StartCoroutine(spawnCoin());
        StartCoroutine(spawnSpike());
    }


    IEnumerator spawnCoin() {

        for (int a = 0;a < numCoins; a++)
        {
            for (int i = 0; i < 50; i++) // try 50 times. Brute force approach, randomly try to spawn and make sure its in the Spawnable zone. 
            {

                Vector3 position = transform.position + Random.insideUnitSphere * 100;
                position.y = this.transform.position.y;
                RaycastHit hitInfo;
                if (Physics.Raycast(position + new Vector3(0, 1, 0), Vector3.down, out hitInfo, 10) && hitInfo.collider.tag == "Ground")
                {
                    Instantiate(CoinPrefab, position, Quaternion.identity);

                    break;
                }
            }
        }
        yield return null;
    }

    IEnumerator spawnSpike()
    {

        for (int a = 0; a < numSpikes; a++)
        {
            for (int i = 0; i < 50; i++) // try 50 times. Brute force approach, randomly try to spawn and make sure its in the Spawnable zone. 
            {

                Vector3 position = transform.position + Random.insideUnitSphere * 100;
                position.y = this.transform.position.y;
                RaycastHit hitInfo;
                if (Physics.Raycast(position + new Vector3(0, 1, 0), Vector3.down, out hitInfo, 10) && hitInfo.collider.tag == "Ground")
                {
                    Instantiate(SpikePrefab, position, Quaternion.identity);

                    break;
                }
            }
        }
        yield return null;
    }


    public void coinDestroy(GameObject coin,int val) {

        numCoins--;
        Destroy(coin);

        uiController.drawCoinValue(val);

        if (numCoins <= 0)
        {

            stopGame();
            uiController.winGame();
        }
    }


    public void loseGame()
    {
        stopGame();
        uiController.losGame();

    }


    private void stopGame() {

        Time.timeScale = 0;

    }

    private void onRestartTimeScaleDef() {

        if (Time.timeScale == 0)
            Time.timeScale = 1;

    }


}
