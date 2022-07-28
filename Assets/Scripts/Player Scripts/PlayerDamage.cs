using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDamage : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    private AudioSource audioManager;
    private int lifescoreCount = 0;

    private bool canDamage;

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
