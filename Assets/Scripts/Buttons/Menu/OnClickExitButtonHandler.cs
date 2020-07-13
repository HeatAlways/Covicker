using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickExitButtonHandler : MonoBehaviour
{
    private void OnMouseUp()
    {
        Application.Quit();   
    }
}
