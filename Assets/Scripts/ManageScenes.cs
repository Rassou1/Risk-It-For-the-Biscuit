using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageScenes : MonoBehaviour
{

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
        SceneManager.LoadScene("Roulette");
    }
}
