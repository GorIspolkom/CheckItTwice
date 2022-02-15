using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.GameLogic;
using System.Collections;

namespace Assets.Scripts.InteractableObjects
{
    // Change learnLevel for use learn hints or only WrongItem hints
    public enum HintType
    {
        WrongItem,
        Item,
        UsableObject,
        InventoryOverflow
    }
    [Serializable]
    public struct Hint
    {
        public HintType hint;
        public GameObject hintObject;
        public float hintTime;
    }
    public class HintManager : MonoBehaviour
    {
        [SerializeField]
        private Hint[] _hintsItems;
        [SerializeField]
        private List<Transform> _hintTable;

        public static HintManager Instance => _instance;
        private static HintManager _instance;

        public void ShowHint(Transform transformHint, HintType type)
        {
            if (CheckAvailableTranform(transformHint))
                StartCoroutine(SpawnHint(transformHint, (int)type));
        }
        private bool CheckAvailableTranform(Transform transformHint)
        {
            if (_hintTable.Contains(transformHint))
                return false;
            else
            {
                _hintTable.Add(transformHint);
                return true;
            }
        }
        private IEnumerator SpawnHint(Transform transformHint, int type)
        {
            GameObject hint = Instantiate(_hintsItems[type].hintObject,
               transformHint.position + new Vector3(0, 3, 0), _hintsItems[type].hintObject.transform.rotation);
            
            yield return new WaitForSecondsRealtime(_hintsItems[type].hintTime);

            Destroy(hint);
            _hintTable.Remove(transformHint);
        }
        private void Awake()
        {
            _hintTable = new List<Transform>();
            _instance = this;
        }

        //    public static HintManager GetHintManager()
        //    {
        //        if (_hintManager == null)
        //        {
        //            _hintManager = FindObjectOfType<HintManager>();
        //        }
        //        return _hintManager;
        //    }
        //    public void ShowHint(Vector3 position, HintType type)
        //    {
        //        if (SessionManager.Instance.CurrentLevel == 0)
        //            ShowHint(position, (int)type);
        //        else if(type == HintType.WrongItem)
        //            ShowHint(position, 0);
        //    }
        //    public void ShowHint(Transform transform, HintType type)
        //    {
        //        ShowHint(transform.position, type);
        //    }
        //    private void ShowHint(Vector3 position, int type)
        //    {
        //        GameObject hint = Instantiate(_hints[type].hintObject,
        //        position + new Vector3(0, 3, 0), _hints[type].hintObject.transform.rotation);
        //        Destroy(hint, _hints[type].hintTime);
        //    }
        //}
    }
}
