﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickPlayButtonHandler : MonoBehaviour
{
    private void OnMouseUp()
    {
        SceneManager.LoadScene("GameScene");
    }
}
