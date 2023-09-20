using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestPuzzle.Manager
{
    public class PrefManager : Singleton<PrefManager>
    {
        public const string KeyPrefix = "CardGame_";
    
        public enum KeyType
        {
            CurrentLevel,
            CurrentCoin
        }
        private readonly string CurrentLevelKey = KeyPrefix + KeyType.CurrentLevel.ToString();
        private readonly string CurrentCoinKey = KeyPrefix + KeyType.CurrentCoin.ToString();

        public int CurrentLevel
        {
            get{ return PlayerPrefs.GetInt(CurrentLevelKey);}
            set { PlayerPrefs.SetInt(CurrentLevelKey, value);}
        }

        public int CurrentCoin
        {
            get{ return PlayerPrefs.GetInt(CurrentCoinKey);}
            set{ PlayerPrefs.SetInt(CurrentCoinKey, value);}
        }

        public void RessetAllKeys()
        {
            foreach (KeyType keyType in System.Enum.GetValues(typeof(KeyType)))
            {
                string key = KeyPrefix + keyType.ToString();
                PlayerPrefs.DeleteKey(key);
            }
        }
    }
}
