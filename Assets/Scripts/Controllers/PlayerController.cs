using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string COIN_TAG = "coin";
    private const string SPIKE_TAG = "Spike";



    private CommandController commandController;
   



   [SerializeField] PlayerStats playerStats;


    private Transform[] pathDraw;

    private void Awake()
    {
        commandController = GetComponent<CommandController>();
      
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touchListener();
        MouseListener();
    }

    private void touchListener()
    {
 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Began)
            {

                var ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out var touchInfo))
                {

                    commandController.addCommands(touchInfo.point);
                }
            }
        }        
        
    }

    private void MouseListener() {

        if (Input.GetMouseButtonDown(0)) {

           
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var clickInfo))
        {
            commandController.addCommands(clickInfo.point);
        }

     }
    }




       


    private void OnTriggerEnter(Collider collision)
    {

        Debug.Log(collision.gameObject.tag);


        if (collision.gameObject.tag == COIN_TAG) {

            playerStats.coins += 100;


            GameManager.Instance.coinDestroy(collision.gameObject,playerStats.coins);

        }

        if (collision.gameObject.tag == SPIKE_TAG)
        {
            GameManager.Instance.loseGame();

        }

    }


}
