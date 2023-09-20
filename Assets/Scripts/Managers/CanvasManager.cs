using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace ChestPuzzle.Manager
{
    public class CanvasManager : Singleton<CanvasManager>
    {
        public GameObject WinPanel, LosePanel;
        public Button NextBtn, TryAgainBtn;
        public int HeartCount;
        public TextMeshProUGUI CurrentCoinTxt, HeartCountTxt;
        [SerializeField] TextMeshProUGUI LevelTxt;
        public bool IsWin;
    
        private void Start()
        {
            NextBtn.onClick.AddListener(NextLevelOnClick);
            TryAgainBtn.onClick.AddListener(RestartGameOnClick);
            LevelTxt.text = (PrefManager.Instance.CurrentLevel + 1).ToString();
            CoinToText();
        }

        private void RestartGameOnClick()
        {
            RestartScene();
        }

        private void NextLevelOnClick()
        {
            if (PrefManager.Instance.CurrentLevel < 4)
            {
                PrefManager.Instance.CurrentLevel++;
            }
            else
            {
                PrefManager.Instance.CurrentLevel = 2;
            }
            RestartScene();
        }

        public void Lose()
        {
            LosePanel.SetActive(true);
            WinPanel.SetActive(false);
        }
        public void Win()
        {
            IsWin = true;
            StartCoroutine(this.DelayedAction(1f,()=> { 
                WinPanel.SetActive(true);
                LosePanel.SetActive(false);
            }));
        }
        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void CoinIncrease(int value)
        {
            PrefManager.Instance.CurrentCoin += value;
            CoinToText();
        }
        private void CoinToText()
        {
            CurrentCoinTxt.text = PrefManager.Instance.CurrentCoin.ToString();
        }
        public void HeartToText(int value)
        {
            HeartCount += value;
            HeartCountTxt.text = HeartCount.ToString();
        }
    }
}


