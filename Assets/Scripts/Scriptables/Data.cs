using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestPuzzle", menuName = "ChestDatas")]
public class Data : ScriptableObject
{
    public List<Material> ChestMaterials = new List<Material>();
    public List<Sprite> LevelPlanSprites = new List<Sprite>();
    public List<string> LevelPlanIntList = new List<string> 
    { 
        "1,2,3", 
        "5,6,7,9" 
    };

    public List<int> GreenBoxCount = new List<int>();
  
}
