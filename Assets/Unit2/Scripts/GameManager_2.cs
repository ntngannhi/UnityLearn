using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_2 : MonoBehaviour
{
   private int lives = 3;
   private int scores = 0;

   public void DecreaseLives(int value)
   {
      lives -= value;
      if (lives <= 0)
      {
         Debug.Log("Game Over");
      }
      Debug.Log("Lives = "+ lives);
   }

   public void AddScore(int value)
   {
      scores += value;
      Debug.Log("Score = "+ scores);
   }
}
