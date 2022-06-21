using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiM;
    [SerializeField] InputManager inputM;
    [SerializeField] PlayerShip pShip;
    Camera mainCam;
    [SerializeField] float amountToIncreaseForcePerUpdate;
    int state; // 0 for ship not launched nor loading. 1 for loading. 2 for launched
    private void Awake()
    {
        state = 0;
        Time.timeScale = 1f;
        mainCam = FindObjectOfType<Camera>();
        inputM.clickPress.AddListener(startLoadingShip);
        inputM.clickLetGo.AddListener(fireShip);
        pShip.collidedWithTarget.AddListener(winLevel);
    }
    private void fireShip()
    {
        if (state == 1)
        {
            pShip.launch(mainCam.ScreenToWorldPoint(Input.mousePosition));
            changeState(2);
        }
    }
    private void updateShipForce()
    {
        pShip.loadForce(amountToIncreaseForcePerUpdate);
        uiM.updateSlider(pShip.getForce() / pShip.maxForce);
    }
    private void startLoadingShip()
    {
        if (state == 0)
        {
            changeState(1);
        }
    }
    private void winLevel() 
    {
        //Tell ui to pop up panel
        Time.timeScale = 0f;       
    }

    //Updates
    private void Update()
    {
        inputM.receiveInput();
    }

    private void FixedUpdate()
    {
        if (state == 1)
        {
            updateShipForce();
        }
    }
    //End Updates


    //Gets and sets
    private void changeState(int newState)
    {
        state = newState;

        // End gets and sets
    }
}
