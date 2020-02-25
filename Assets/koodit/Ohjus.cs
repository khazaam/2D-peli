using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ohjus : MonoBehaviour {


    public float ohjusSpeed;

    private Rigidbody2D OhjusRB;

    public GameObject Ammus_effect;

	// Use this for initialization
	void Start () {
        OhjusRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        OhjusRB.velocity = new Vector2(ohjusSpeed * transform.localScale.x, 0);
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player1")
        {
            FindObjectOfType<PelinManakeri>().HurtP1();
        }

        if (other.tag == "Player2")
        {
            FindObjectOfType<PelinManakeri>().HurtP2();
        }

        Instantiate(Ammus_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
