using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        
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

    private void OnTriggerEnter(Collider other)
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

            Destroy(this.gameObject);
        }

        if (other.tag == "Lazer")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    } 
}
