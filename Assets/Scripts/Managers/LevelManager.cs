using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestPuzzle.Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] Data _data;
        [SerializeField] Image _levelPlanImg;
        private void Start()
        {
            GetLevelPlan();
        }

        private void GetLevelPlan()
        {
            _levelPlanImg.sprite = _data.LevelPlanSprites[PrefManager.Instance.CurrentLevel];
        }
    }
}

