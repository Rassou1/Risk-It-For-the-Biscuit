using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToGame : MonoBehaviour
{
    [SerializeField]
    Button returnButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        returnButton.onClick.AddListener(ReturnToMainGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnToMainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
