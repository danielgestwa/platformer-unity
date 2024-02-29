using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public PlayerMovement player;
    private Dictionary<string, string> scenes = new Dictionary<string, string>();
    private string currentSceneName;

    void Start() {
        currentSceneName = SceneManager.GetActiveScene().name;
        scenes.Add("Level 1", "Level 2");
        scenes.Add("Level 2", "Level 3");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isDead) {
            SceneManager.LoadScene(currentSceneName);
        }

        if(player.nextStage) {
            if(scenes.ContainsKey(currentSceneName)) {
                SceneManager.LoadScene(scenes[currentSceneName]);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
