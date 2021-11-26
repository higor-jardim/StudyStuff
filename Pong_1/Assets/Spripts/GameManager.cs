using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    public StateMachine stateMachine;

    public static GameManager Instance;

    public float timeToSetBallFree = 1f;

    public Action OnResetGame;

    private bool _canSetBallFree;

    [Header("Menus")]
    public GameObject uiMainMenu;

    
    private void Awake()
    {
        Instance = this;
    }

    public void SwitchStateToReset()
    {

        StateMachine.Instance.ResetPosition();
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    private void SetBallFree()
    {
        if (!_canSetBallFree) return;
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        _canSetBallFree = true;
        ballBase.CanMove(true);
    }

    public void EndGame()
    {
        uiMainMenu.SetActive(true);
        OnResetGame?.Invoke();
        _canSetBallFree = false;
        ballBase.CanMove(false);
        ballBase.ResetBall();
    }

}
