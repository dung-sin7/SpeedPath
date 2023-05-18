using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform currentPlayer;
    [SerializeField] private Transform startPoint;

    private void Awake()
    {
        this.LoadComponents();
    }

    private void Reset()
    {
        this.LoadComponents();
    }

    private void Update()
    {
        this.CheckOnResetScene();
    }
    private void LoadComponents()
    {
        this.LoadPlayer();
        this.LoadStartPoint();
    }

    private void LoadStartPoint()
    {
        if (this.startPoint != null) return;

        this.startPoint = GameObject.Find("StartPoint").transform;
    }

    private void LoadPlayer()
    {
        if (this.currentPlayer != null) return;
        
        currentPlayer = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        this.MoveToStartPoint();
    }

    private void MoveToStartPoint()
    {
        this.currentPlayer.position = this.startPoint.position;
    }

    private void CheckOnResetScene()
    {
        if (!CheckOnPlayerDead()) return;
        this.ResetScene();

    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool CheckOnPlayerDead()
    {
        DamageReceived damageReceived = this.currentPlayer.GetComponentInChildren<DamageReceived>();
        if (damageReceived == null) return false;
        if (!damageReceived.IsDead) return false;
        return true;
    }
}
