using UnityEngine;
using System.Collections;
using System;

public class CovidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _covidFastObject;
    [SerializeField] private GameObject _covidMediumObject;
    [SerializeField] private GameObject _covidBossObject;

    private System.Random _random = new System.Random();

    public void GenerateCovid(CovidType type)
    {
        GenerateCovid(type, CreateNewCovidPosition());
    }

    public void GenerateCovid(CovidType type, Vector3 position)
    {
        switch (type)
        {
            case CovidType.FAST:
                Instantiate(_covidFastObject, position, _covidFastObject.transform.rotation);
                break;
            case CovidType.MEDIUM:
                Instantiate(_covidMediumObject, position, _covidMediumObject.transform.rotation);
                break;
            case CovidType.BOSS:
                Instantiate(_covidBossObject, position, _covidBossObject.transform.rotation);
                break;
        }
    }

    public void GenerateRandomCovid()
    {
        CovidType type = GetRandomCovidType(_random);
        GenerateCovid(type);
    }

    private Vector3 CreateNewCovidPosition()
    {
        return new Vector3(
            UnityEngine.Random.Range(10f, 25f),
            UnityEngine.Random.Range(-3.0f, 3.0f),
            1
        );
    }

    private CovidType GetRandomCovidType(System.Random random)
    {
        Array values = Enum.GetValues(typeof(CovidType));
        return (CovidType)values.GetValue(random.Next(values.Length - 1));
    }

    public enum CovidType
    {
        FAST,
        MEDIUM,
        BOSS
    }
}
