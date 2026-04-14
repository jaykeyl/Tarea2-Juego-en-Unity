using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text collectiblesTextP1;
    public TMP_Text collectiblesTextP2;
    public Transform collectiblesParent;

    private int collectiblesP1 = 0;
    private int collectiblesP2 = 0;

    private bool gameEnded = false; // evita cargar muchas veces la escena 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (gameEnded) return;

        if (collectiblesParent != null && collectiblesParent.childCount == 0)
        {
            gameEnded = true;

            if (IsLevel3())
            {
                DecideWinnerAndLoadScene();
            }
            else
            {
                LoadNextScene();
            }
        }
    }

    bool IsLevel3()
    {
        return SceneManager.GetActiveScene().buildIndex == 3;
    }

    void DecideWinnerAndLoadScene()
    {
        if (collectiblesP1 > collectiblesP2)
        {
            SceneManager.LoadScene(4);
        }
        else if (collectiblesP2 > collectiblesP1)
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            SceneManager.LoadScene(6); 
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AddCollectible(string playerTag)
    {
        if (playerTag == "Player1")
        {
            collectiblesP1++;
            if (collectiblesTextP1 != null)
                collectiblesTextP1.text = collectiblesP1.ToString();
        }
        else if (playerTag == "Player2")
        {
            collectiblesP2++;
            if (collectiblesTextP2 != null)
                collectiblesTextP2.text = collectiblesP2.ToString();
        }
    }

    public void RemovePoint(string playerTag)
    {
        if (playerTag == "Player1")
        {
            collectiblesP1 = Mathf.Max(0, collectiblesP1 - 1);
            if (collectiblesTextP1 != null)
                collectiblesTextP1.text = collectiblesP1.ToString();
        }
        else if (playerTag == "Player2")
        {
            collectiblesP2 = Mathf.Max(0, collectiblesP2 - 1);
            if (collectiblesTextP2 != null)
                collectiblesTextP2.text = collectiblesP2.ToString();
        }
    }
}