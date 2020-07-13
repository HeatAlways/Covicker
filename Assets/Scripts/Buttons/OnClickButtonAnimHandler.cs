using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButtonAnimHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }

    private void OnMouseUp()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
