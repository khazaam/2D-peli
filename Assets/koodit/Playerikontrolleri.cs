using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerikontrolleri : MonoBehaviour {

    public float liikuntaNopeus;//movespeed
    public float hyppyVoima;//jumpforce

    public KeyCode left; //left
    public KeyCode right;//right
    public KeyCode jump;//hyppy

    public KeyCode heiTaJuttu; //throw

    private Rigidbody2D RigitysBodi;//rigidbodi mikä on kiinni hahmossa

    public Transform groundCheckPoint; //onkomaassa
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public GameObject Ammus;
    public bool isGrounded; //onko maassa true or false
    public Transform ammuskele;

    public AudioSource ammuAani;

    private Animator anim;//animaatiot tulee tämän kautta


    

	// Use this for initialization
	void Start () {
        RigitysBodi = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if(Input.GetKey(left))
        {
            RigitysBodi.velocity = new Vector2(-liikuntaNopeus, RigitysBodi.velocity.y);
        } else if (Input.GetKey(right))
            {
            RigitysBodi.velocity = new Vector2(liikuntaNopeus, RigitysBodi.velocity.y);
        } else
        {
            RigitysBodi.velocity = new Vector2(0, RigitysBodi.velocity.y);
        }
        if(Input.GetKeyDown(jump) && isGrounded)
        {
            RigitysBodi.velocity = new Vector2(RigitysBodi.velocity.x, hyppyVoima);
        }

        if(Input.GetKeyDown(heiTaJuttu)) //ammutaan
        {
            GameObject ohjusKlooni = (GameObject)Instantiate(Ammus, ammuskele.position, ammuskele.rotation);
            ohjusKlooni.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");

            ammuAani.Play();
        }

        if(RigitysBodi.velocity.x <0)//kääntyminen
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(RigitysBodi.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetBool("Grounded", isGrounded);

	}
}
