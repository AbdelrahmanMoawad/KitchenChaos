using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStartCountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;

    private Animator animator;
    private int previousCountDownNumber;
    private const string NUMBER_POP_TRIGGER = "NumberPop";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if(GameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(GameManager.Instance.GetcountdownToStartTimer());
        countDownText.text = countdownNumber.ToString();

        if (previousCountDownNumber != countdownNumber)
        {
            previousCountDownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POP_TRIGGER);
            SoundManager.Instance.PlayCountDownSound();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
