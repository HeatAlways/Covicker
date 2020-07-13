using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CovidBoss : Covid
{
    [SerializeField] private float _fastCovidSpawnDelay;

    private float m_timePassed = 0;

    private new void FixedUpdate()
    {
        base.FixedUpdate();
        m_timePassed += Time.deltaTime;
        if (m_timePassed >= _fastCovidSpawnDelay)
        {
            GameController.Instance.CovidSpawner.GenerateCovid(CovidSpawner.CovidType.FAST, transform.position);
            m_timePassed = 0;
        }
    }
}
