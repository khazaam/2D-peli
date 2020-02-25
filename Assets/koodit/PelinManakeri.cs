using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PelinManakeri : MonoBehaviour {


    public GameObject player1;
    public GameObject player2;

    public int P1Life;//pelaaja ykkösen hitpointit/sydämet
    public int P2Life;

    public GameObject P1Wins;//peli päättyy ykkönen voitti
    public GameObject P2Wins;//peli päättyy ykkönen voitti

    public GameObject[] p1Hearts;//pelaaja ykkösen sydämet
    public GameObject[] p2Hearts;//pelaaja ykkösen sydämet

    public AudioSource hurtSound;

    public string mainMenu;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(P1Life <= 0)
        {
            player1.SetActive(false);
            P2Wins.SetActive(true);
        }
        if (P2Life <= 0)
        {
            player2.SetActive(false);
            P1Wins.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }



    public void HurtP1()
    {
        P1Life -= 1;
        for(int i = 0; i < p1Hearts.Length; i++)
        {
            if(P1Life > i)
            {
                p1Hearts[i].SetActive(true);
            } else
            {
                p1Hearts[i].SetActive(false);
            }
        }

        hurtSound.Play();
    }

    public void HurtP2()
    {
        P2Life -= 1;
        for (int i = 0; i < p2Hearts.Length; i++)
        {
            if (P2Life > i)
            {
                p2Hearts[i].SetActive(true);
            }
            else
            {
                p2Hearts[i].SetActive(false);
            }
        }

        hurtSound.Play();
    }

}
