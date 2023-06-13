using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private Player _player;

    private Animator _anim;

    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();

        if (_player == null){
            Debug.LogError("The Player is null");
        }

        _anim = GetComponent<Animator>();

        if (_anim == null){
            Debug.LogError("Animator is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4 m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);


        // if bottom of the screen, respawn at top with new random x value
        if(transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.transform.name);

        // if other is Player, damage player and destroy this
        if (other.tag == "Player")
        {
       
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;

            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);
            
        }

        if (other.tag == "Lazer")
        {
            Destroy(other.gameObject);

            if(_player != null){
                _player.AddScore(10);
            }

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;

            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);

        }

    } 
}
