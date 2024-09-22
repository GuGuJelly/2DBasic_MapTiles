using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class ItemScripts : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    //private void OnEnable()
    //{
    //    model.OnSCOREChanged += UpdateSCORE;
    //}
    //
    //private void OnDisable()
    //{
    //    model.OnSCOREChanged -= UpdateSCORE;
    //}
    //
    //private void Start()
    //{
    //    UpdateSCORE(model.SCORE);
    //}

    //#region UI
    // private void UpdateSCORE(int score)
    // {
    //     scoreText.text = $"{score}";
    // }
    // #endregion

    private void Start()
    {
        //scoreText.text = $"Gem: {score}";
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerController.score++;
            gameObject.SetActive(false);
        }
    }
}
