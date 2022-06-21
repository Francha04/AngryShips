using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent clickPress;
    public UnityEvent clickLetGo;
    public void receiveInput()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            clickPress.Invoke();
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            clickLetGo.Invoke();
        }
    }
}
