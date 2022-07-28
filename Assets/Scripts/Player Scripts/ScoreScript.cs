using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI coinTextScore;
    private AudioSource audioManager;
    private int scoreCount = 0;

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
        //coinTextScore = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        coinTextScore.text = scoreCount.ToString();
    }
    /*void Start()
    {
       
      coinTextScore = GameObject.Find("CoinText").GetComponent < TextMeshPro > ();   //not related to tag find nd connect to gameobject of same name
        
    }*/

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == MyTags.COIN_TAG)
        {
            //Debug.Log("Attacked");
            audioManager.Play();
            collision.gameObject.SetActive(false);
            scoreCount++;
            // Debug.Log(scoreCount);
            //Instantiate(coinTextScore);
            //coinTextScore.text = "x"+ scoreCount;
           
           
        }

    }
}
