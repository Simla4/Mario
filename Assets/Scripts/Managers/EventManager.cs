using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action OnPlayerJump;
    public static Action OnPlayerInGround;
    public static Action OnPlayerCollisionEnemy;
    public static Action OnPlayerKillEnemy;
    public static Action OnGamePlay;
    public static Action OnGameWin;
    public static Action OnGameFail;
    public static Action OnGameRetry;
    public static Action OnPassNextLevel;
}
