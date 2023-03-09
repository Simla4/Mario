using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Callbacks

    private void Update()
    {
        HandleInput();
    }

    #endregion

    #region OtherMethods

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EventManager.OnPlayerJump?.Invoke();
        }
    }

    #endregion
}
