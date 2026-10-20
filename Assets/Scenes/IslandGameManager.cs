using UnityEngine;

public class IslandGameManager : MonoBehaviour
{
    public static IslandGameManager instance;

    public IslandTile[] islands;

    public GameObject winScreen;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;

        winScreen.SetActive(false);

        // Choose random stable island
        int randomIsland =
            Random.Range(0, islands.Length);

        islands[randomIsland].isStable = true;

        Debug.Log(
            "Stable Island: " +
            islands[randomIsland].name
        );
    }

    public void WinGame()
    {
        winScreen.SetActive(true);

        Time.timeScale = 0;
    }
}
