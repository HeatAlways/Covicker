using UnityEngine;
using System.Collections;

public class ClickEffectRemover : MonoBehaviour
{
    private float _timePassed = 0;

    private void Update()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed > 1)
        {
            Destroy(gameObject);
        }
    }
}
