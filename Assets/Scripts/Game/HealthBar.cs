using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDeath;

    private const int MAXIMUM_HEALTH = 3;
    private int _currentHealth = MAXIMUM_HEALTH;

    public void Decrease()
    {
        if (--_currentHealth <= 0)
        {
            _onDeath.Invoke();
            SceneManager.LoadScene("FinishScene");
        }
        GameObject healthPoint = transform.GetChild(_currentHealth).gameObject;
        healthPoint.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
