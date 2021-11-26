using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 8;
    public Image uiPlayer;
    public string playerName;

    [Header("Key Setup)]")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;
    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    private void Awake()
    {
        ResetPlayer();
    }

    private void Start()
    {
        GameManager.Instance.OnResetGame += ResetPlayer;
    }
    private void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();

        Vector3 initialPos = transform.localPosition;
        initialPos.y = 0;
        transform.localPosition = initialPos;
    }

    private void Update()
    {
        if (Input.GetKey(keyCodeMoveUp))
            myRigidbody2D.MovePosition(transform.position + transform.up * speed * Time.deltaTime * 100);
        else if (Input.GetKey(keyCodeMoveDown))
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed * Time.deltaTime * 100);
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        Debug.Log(currentPoints);
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SavePlayerWin(this);
        }
    }

    public void SetName(string s)
    {
        playerName = s;
    }

}
