using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ManageScenes : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    [SerializeField]
    Button rouletteButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rouletteButton.onClick.AddListener(SwapToRouletteScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwapToRouletteScene()
    {
        //SceneManager.LoadScene("Roulette");
        //SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Roulette"));        
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Roulette", LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Roulette"));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
