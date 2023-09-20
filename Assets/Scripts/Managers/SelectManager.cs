using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ChestPuzzle.Grid;

namespace ChestPuzzle.Manager
{
    public class SelectManager : MonoBehaviour
    {
        public Transform selectedObject=null;
        public Transform secondObject=null;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider != null&&hit.collider.CompareTag("Chest") && 
                            !hit.collider.GetComponent<ChestSelf>().IsMoving)
                        {
                            if (selectedObject == null)
                            {
                                selectedObject = hit.transform;
                                selectedObject.GetComponent<ChestSelf>().Highlight.SetActive(true);
                            }
                            else
                            {
                             secondObject = hit.transform;
                              secondObject.GetComponent<ChestSelf>().Highlight.SetActive(true);

                                if (selectedObject == secondObject)
                                {
                                    ClearObjects();
                                    return;
                                }

                             SwapObjects(selectedObject, secondObject);
                            }
                        }
                    }
                }
            }
        }
        public void SwapObjects(Transform firstObject, Transform secondObject)
        {
            firstObject.GetComponent<ChestSelf>().IsMoving = true;
            secondObject.GetComponent<ChestSelf>().IsMoving = true;
            firstObject.DOJump(secondObject.position, 1, 1, 1);
            secondObject.DOJump(firstObject.position,2,1,1).OnComplete(() => {
                firstObject.GetComponent<ChestSelf>().IsMoving = false;
                secondObject.GetComponent<ChestSelf>().IsMoving = false;
                firstObject.GetComponent<ChestSelf>().Highlight.SetActive(false);
                secondObject.GetComponent<ChestSelf>().Highlight.SetActive(false);
                
                //CanvasManager.Instance.HeartCount--;
                CanvasManager.Instance.HeartToText(-1);

                //int heartCount = 0;
                //if (int.TryParse(CanvasManager.Instance.HeartCountTxt.text, out heartCount))
                //{
                //    CanvasManager.Instance.HeartCountTxt.text = (heartCount - 1).ToString();
                //}
                GridGenerator.Instance.CheckCorrect();
                if (CanvasManager.Instance.HeartCountTxt.text == "0" && CanvasManager.Instance.IsWin == false)
                {
                    CanvasManager.Instance.Lose();
                }
            });
            
            ClearObjects();
        }
        private void ClearObjects()
        {
            selectedObject.GetComponent<ChestSelf>().Highlight.SetActive(false);
            secondObject.GetComponent<ChestSelf>().Highlight.SetActive(false);
            selectedObject = null;
            secondObject = null;

        }


    }
}
