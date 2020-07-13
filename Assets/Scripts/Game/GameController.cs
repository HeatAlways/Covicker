using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _spawnerObject;
    [SerializeField] private GameObject _healthObject;
    [SerializeField] private GameObject _scoreObject;
    [SerializeField] private GameObject _clickEffectObject;
    [SerializeField] private float _timeToCovidRespawn;
    [SerializeField] private float _timeToBossRespawn;
    [SerializeField] private float _gameSpeedMultiplier;

    private CovidSpawner _covidSpawner;
    private HealthBar _healthBar;
    private Score _score;

    private float _respawnTimer = 0;
    private float _bossRespawnTimer = 0;

    private const float DELTA_SCALE_TIME = 0.00001f;

    private static GameController _instance = null;

    public static GameController Instance 
    {
        get { return _instance; }
    }

    public CovidSpawner CovidSpawner
    {
        get { return _covidSpawner; }
    }

    public HealthBar HealthBar
    {
        get { return _healthBar; }
    }

    public Score Score
    {
        get { return _score; }
    }

    public GameObject ClickEffectPrefab {
        get { return _clickEffectObject; }
    }

    private void Start()
    {
        if (_instance == null)
        { 
            _instance = this;
        }
        else if (_instance == this)
        { 
            Destroy(gameObject); 
        }

        Init();
    }

    private void Init()
    {
        _covidSpawner = _spawnerObject.GetComponent<CovidSpawner>();
        _healthBar = _healthObject.GetComponent<HealthBar>();
        _score = _scoreObject.GetComponent<Score>();

        _score.Restart();

        for (int i = 0; i < 5; i++)
        {
            _covidSpawner.GenerateRandomCovid();
        }
        Time.timeScale = 1;
    }

    private void Update()
    {
        Time.timeScale += DELTA_SCALE_TIME * _gameSpeedMultiplier;
        _respawnTimer += Time.deltaTime;
        _bossRespawnTimer += Time.deltaTime;

        if (_respawnTimer >= _timeToCovidRespawn)
        {
            _covidSpawner.GenerateRandomCovid();
            _respawnTimer = 0;
        }

        if (_bossRespawnTimer >= _timeToBossRespawn)
        {
            _covidSpawner.GenerateCovid(CovidSpawner.CovidType.BOSS);
            _bossRespawnTimer = 0;
        }
    }
}
