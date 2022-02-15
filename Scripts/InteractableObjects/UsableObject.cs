﻿using Assets.Scripts.GameLogic;
using Assets.Scripts.Items;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.InteractableObjects
{
    public class UsableObject : InteractableObject
    {
        public override void Use()
        {
            if (IsInteractable && SessionManager.Instance.Inventory.Count > 0)
            {
                Debug.Log("Use an object named - " + objectData.objectName);
                if (objectData.posibleItem.Length > 0)
                {
                    if (IsBreaking)
                        foreach (ItemData neededItem in objectData.posibleItem)
                            if (SessionManager.Instance.CurrentItem == neededItem)
                            {
                                SetBreaking(false);
                                GameHandler.Instance.RemoveItem(neededItem);
                                GameHandler.Instance.audioManager.PlayUseSound(objectData.useSound);
                                break;
                            }
                            else
                            {
                                HintManager.Instance.ShowHint(transform, HintType.WrongItem);
                                GameHandler.Instance.audioManager.PlayWrongSound();
                            }
                }
                else
                {
                    SetBreaking(!IsBreaking);
                    GameHandler.Instance.audioManager.PlayUseSound(objectData.useSound);
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && IsInteractable)
            {
                IsUsable = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsUsable = false;
            }
        }
        public void FixedUpdate()
        {
            bool showHint = (transform.position - GameHandler.Instance.player.position).magnitude < GameHandler.Instance.ItemValidDistance;
            if (showHint && IsBreaking)
                HintManager.Instance.ShowHint(transform, HintType.UsableObject);
        }
    }
}