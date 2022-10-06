using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }

}
