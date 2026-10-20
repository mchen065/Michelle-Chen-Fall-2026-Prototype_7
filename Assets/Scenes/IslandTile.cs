using UnityEngine;

public class IslandTile : MonoBehaviour
{
    public int health = 3;
    public bool isStable = false;

    public void DamageIsland()
    {
        // Stable island never breaks/becomes smaller
        if (isStable)
        {
            return;
        }

        health--;

        Debug.Log("Island Health: " + health);

        // Make the island look smaller
        if (health == 2)
        {
            transform.localScale *= 0.9f;
        }

        if (health == 1)
        {
            transform.localScale *= 0.8f;
        }

        // Island breaks
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
