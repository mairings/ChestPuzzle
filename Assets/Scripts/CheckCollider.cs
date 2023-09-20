using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestPuzzle.Chest;

namespace ChestPuzzle.Chest
{
    public class CheckCollider : MonoBehaviour
    {
        public bool IsOk;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Chest") && other.GetComponent<ChestSelf>().ChestColor == ChestSelf.ChestColors.Color3)
            {
                IsOk = true;
            }
            else
            {

            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Chest") && other.GetComponent<ChestSelf>().ChestColor == ChestSelf.ChestColors.Color3)
            {
                IsOk = false;
            }
        }
    }
}

