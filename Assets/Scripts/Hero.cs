using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefub, _enemyPrefub;
    [SerializeField] private Transform _bulletSpawn, _enemySpawn;
    [SerializeField] private float _speed;
    private static int _id = 0;
    private Vector3 _direction;
    private bool _isFire;
    private bool _isSprint;
    private bool _isEner;

    public GameObject _bomb, Effects;

    private void Awake()
    {
        _isFire = false;
        _isEner = false;
        name = "Hero" + _id++;
        _direction = Vector3.zero;
    }

    void Start()
    {
        FindObjectOfType<Hero>();
    }

    //Update is called once per frame
    void Update()
    {
        _isFire = Input.GetMouseButtonDown(0);

        _isSprint = Input.GetButton("Sprint");

        _isEner = Input.GetButton("Enem");
    }

    private void FixedUpdate()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        
        float sprint = (_isSprint) ? 2f : 1f;

        transform.Translate(_direction.normalized * _speed * sprint * Time.fixedDeltaTime);

        if (_isFire)
        {
           Fire(); 
        } 

        if (_isEner)
        {
            Energence();
        }
    }

    private void Fire()
    {
        _isFire = false;
        GameObject bullet = Instantiate(_bulletPrefub, _bulletSpawn.position,  Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialization(5f);
    }

    private void Energence()
    {
        _isEner = false;
        GameObject enemy = Instantiate(_enemyPrefub, _enemySpawn.position, Quaternion.identity);
        enemy.GetComponent<Enemy>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Effects.SetActive(true);
            _bomb.GetComponent<Animator>().SetBool("On", true);
        }
    }
}