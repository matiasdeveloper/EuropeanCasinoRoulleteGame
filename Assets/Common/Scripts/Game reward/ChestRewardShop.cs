﻿using GameServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestRewardShop : MonoBehaviour
{
    public void Start()
    {
        ServiceManager.Instance.OnRewardShopFinished.AddListener(HandleOnRewardShopFinish);
    }
    private void HandleOnRewardShopFinish(bool isFinish, int payment)
    {
        Debug.Log("The payment has finished!");
        if (isFinish == true)
        {
            isWin(payment);
        }
    }
    private void isWin(int payment) 
    {
        if (GameManager.Instance.getIsInMenu())
        {
            MenuUi.Instance.OnRewardFinishedUI("Thanks you!", payment.ToString(), true);
            Debug.Log("Reward the player!");
            Debug.Log("You win in menu: $ " + payment);

            MoneySystemController.Instance._cashNew = payment;
            MoneySystemController.Instance.SavePlayerCash();

            MenuUi.Instance.SetMoneyUi();
        }
        else
        {
            CanvasUI.Instance.turnWinOrLost("Incredible!", payment.ToString(), true, payment);
            Debug.Log("Reward the player!");
            Debug.Log("You win in game: $  " + payment);

            RoundController.Instance.ActivateButtons(true);
            RoundController.Instance.OnRewardFinished(payment);
        }
    }
}
