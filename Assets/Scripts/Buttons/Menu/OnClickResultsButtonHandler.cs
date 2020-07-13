using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickResultsButtonHandler : MonoBehaviour
{
    private void OnMouseUp()
    {
        SceneManager.LoadScene("ResultsScene");
    }
}
