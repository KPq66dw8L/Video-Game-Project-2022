using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BombCooldown : MonoBehaviour
{
    [SerializeField] //to be able to see the variable in the Unity editor, while being private
    private Image imageCooldown;
    [SerializeField]
    //private TMP_Text textCooldown;
    private TMP_Text textBombNumber;

    //variables for cooldown
    private bool isCooldown = false;
    public static float cooldownTime = 2.0f;
    private float cooldownTimer = 0.0f;
    public static bool activate;


    // Start is called before the first frame update
    void Start()
    {
        textBombNumber.gameObject.SetActive(true);
        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //show the remaining number of bombs left, in the button
        textBombNumber.text = playerMovement.bomb_number.ToString();
        if (activate)
        {
            UseBomb();
        }
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            imageCooldown.fillAmount = 0.0f;
            if (playerMovement.max_bomb_number == playerMovement.bomb_number)
            {
                activate = false;
            }
        }
        else
        {
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    public void UseBomb()
    {
        if (isCooldown)
        {
            //user has clicked a bomb while in use
        }
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }
}
