using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestPuzzle.Manager;
using ChestPuzzle.Chest;

namespace ChestPuzzle.Grid
{
    public class GridGenerator : Singleton<GridGenerator>
    {
        [SerializeField] GameObject _gridCellPrefab, _colliderCellPrefab;
        [SerializeField] int _numRows = 4;
        [SerializeField] int _numColumns = 4;
        [SerializeField] float _cellSize = 1;
        [SerializeField] Data _chestData;
        [SerializeField] List<int> _correctPlanList = new List<int>();
        [SerializeField] List<GameObject> _chestList = new List<GameObject>();
        [SerializeField] List<GameObject> _grenChestList = new List<GameObject>();
        [SerializeField] List<GameObject> _colliderList = new List<GameObject>(); 
        private void Start()
        {
            GenerateGrid();
            GetLevelPlan();
            GetRandomNums();
            GetChestMaterials();
            CheckCorrect();
        }

        private void GenerateGrid()
        {
            for (int row = 0; row < _numRows; row++)
            {
                for (int column = 0; column < _numColumns; column++)
                {
                    Vector3 cellPosition = new Vector3(column * _cellSize, 0, row * _cellSize);
                    GameObject cell = Instantiate(_gridCellPrefab, cellPosition, Quaternion.identity, transform);
                    GameObject colliderCell = Instantiate(_colliderCellPrefab, cellPosition, Quaternion.identity, transform);
                    _colliderList.Add(colliderCell);
                    _chestList.Add(cell);
                }
            }
            

        }
        private void GetRandomNums()
        {
            List<int> randomNumList = new List<int>();
            int count = _correctPlanList.Count;

            for (int i = 0; i < count; i++)
            {
                int randomNumber;
                do
                {
                    randomNumber = Random.Range(0, _numRows*_numColumns);
                } while (randomNumList.Contains(randomNumber));

                randomNumList.Add(randomNumber);
                _chestList[randomNumber].GetComponent<ChestSelf>().BoxMr.material = _chestData.ChestMaterials[2];
                _chestList[randomNumber].GetComponent<ChestSelf>().LidMr.material = _chestData.ChestMaterials[2];
                _chestList[randomNumber].GetComponent<ChestSelf>().ChestColor = ChestSelf.ChestColors.Color3;
                
                _grenChestList.Add(_chestList[randomNumber]);
            }
            CanvasManager.Instance.HeartToText(_correctPlanList.Count + 1);
        }
     
        private void GetChestMaterials()
        {
            foreach (GameObject item in _chestList)
            {
                if (item.GetComponent<ChestSelf>().ChestColor != ChestSelf.ChestColors.Color3)
                {
                    int randomIndex = GetRandomMaterialIndex();
                    item.GetComponent<ChestSelf>().BoxMr.material = _chestData.ChestMaterials[randomIndex];
                    item.GetComponent<ChestSelf>().LidMr.material = _chestData.ChestMaterials[randomIndex];
                }
            }
        }

        private int GetRandomMaterialIndex()
        {
            int randomIndex=0;
            do
            {
                randomIndex = Random.Range(0, 4);
            }
            while (randomIndex == 2);
            return randomIndex;
        }

        private void GetLevelPlan()
        {

            string[] parts = _chestData.LevelPlanIntList[PrefManager.Instance.CurrentLevel].Split(',');
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    _correctPlanList.Add(number);
                }
            }
        }

        public void CheckCorrect()
        {
            foreach (int item in _correctPlanList)
            {
                if (_colliderList[item].GetComponent<CheckCollider>().IsOk == false)
                {
                  
                    return;
                }
                else
                {
                }
            }
            foreach (GameObject item in _grenChestList)
            {
                item.GetComponent<ChestSelf>().OpenCloseAnimation(true);
            }
            CanvasManager.Instance.Win();
        }
    }
}

