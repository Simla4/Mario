using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    [SerializeField] private int maxHP = 3;
    [SerializeField] private int currentHP;
    

    #endregion

    #region Callbacks

    private void Start()
    {
        currentHP = maxHP;
    }

    #endregion

    #region OtherMethods

    private void ResetHP()
    {
        
    }

    private void DecreaseHP()
    {
        
    }

    #endregion
}
