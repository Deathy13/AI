using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace GoneHome
{
    public class GameManager : MonoBehaviour
    {
      public void NextLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        public void RestartLevel()
        {
            FollowEnemy[] followEnemies = FindObjectsOfType<FollowEnemy>();

            foreach (var enemy in followEnemies)
            {
                enemy.Reset();
            }
            PatrolEnemy[] patrolenemies = FindObjectsOfType<PatrolEnemy>();
            foreach (var enemy in patrolenemies)
            {
                enemy.Reset();
            }



            Player player = FindObjectOfType<Player>();
            player.Reset();
        }

    }
}
