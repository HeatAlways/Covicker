using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Covid : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private float _health;
    [SerializeField] private int _scoreForKilling;
    
    protected Animator _rotateAnimator;

    private Transform _transform;

    protected void Start()
    {
        _transform = transform;
        _rotateAnimator = GetComponent<Animator>();
        _rotateAnimator.SetFloat("offset", Random.Range(0f, 1f));
        _rotateAnimator.SetFloat("speed", Random.Range(-_animationSpeed, _animationSpeed));
        
    }

    protected void FixedUpdate()
    {
        _transform.position -= new Vector3(_movingSpeed, 0, 0);
        if (_transform.position.x <= -8)
        {
            Destroy(this);
            GameController.Instance.HealthBar.Decrease();
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

    private void ClickEffectPlay()
    {
        Animator clickEffectAnimation = Instantiate(GameController.Instance.ClickEffectPrefab).GetComponent<Animator>();
        clickEffectAnimation.transform.position = new Vector3(
            _transform.position.x,
            _transform.position.y,
            -3
        );
        clickEffectAnimation.Play(0);
    }

    private void OnMouseDown()
    {
        ClickEffectPlay();
        if (--_health <= 0)
        {
            Destroy(this);
            GameController.Instance.Score.Increase(_scoreForKilling);
        }
    }
}
