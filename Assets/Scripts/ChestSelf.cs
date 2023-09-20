using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ChestPuzzle.Manager;
using ChestPuzzle.Chest;

    public class ChestSelf : MonoBehaviour
    {
        public MeshRenderer BoxMr,LidMr;
        public Animator ChestAnimator;
        public bool IsMoving;
        [SerializeField] GameObject AwardsSprite;
        [SerializeField] GameObject Lid;
        bool IsOpenClose;
        public GameObject Highlight;
        [Header("Blue, Brown, Green, Purple, Red")]
        public ChestColors ChestColor;
        public enum ChestColors
        {
            Color1,
            Color2,
            Color3,
            Color4,
            Color5
        }
        
        public void OpenCloseAnimation(bool isOpenClose)
        {
            Lid.transform.DOLocalRotate(new Vector3(-100, 0, 0), 1);
            Vector3 spawnPoint = Camera.main.WorldToScreenPoint(transform.position);
            GameObject cloneAwards = Instantiate(AwardsSprite, spawnPoint,Quaternion.identity, CanvasManager.Instance.transform);
            cloneAwards.transform.DOMove(new Vector3(CanvasManager.Instance.CurrentCoinTxt.transform.position.x+100,
            CanvasManager.Instance.CurrentCoinTxt.transform.position.y,
            CanvasManager.Instance.CurrentCoinTxt.transform.position.z), 1);
            cloneAwards.transform.DOScale(cloneAwards.transform.localScale / 6, 2);
            CanvasManager.Instance.CoinIncrease(10);
        }
}

