using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using Debug = System.Diagnostics.Debug;
using File = System.IO.File;

public class GameHandler : MonoBehaviour
{
  
   [SerializeField] private GameObject unitGameObject;
   private IUnit unit;
   private void Awake()
   {
      unit = unitGameObject.GetComponent<IUnit>();
      
      SaveSystem.Init();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.S))
      {
         Save();
      }

      if (Input.GetKeyDown(KeyCode.L))
      {
         Load();
      }
   }

   private void Save()
   {
      Vector3 playerPosition = unit.GetPosition();
      int scoreAmount = unit.GetScoreAmount();

      SaveObject saveObject = new SaveObject()
      {
         scoreAmount = scoreAmount,
         playerPosition = playerPosition
      };
      string json = JsonUtility.ToJson(saveObject);
      
      SaveSystem.Save(json);
   }
   

   private void Load()
   {
      string saveString = SaveSystem.Load();
      
      if(saveString !=null)
      {
         SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
         unit.SetPosition(saveObject.playerPosition);
         unit.SetScoreAmount(saveObject.scoreAmount);
      }
   }
   
   private class SaveObject
   {
      public int scoreAmount;
      public Vector3 playerPosition;
   }
}

