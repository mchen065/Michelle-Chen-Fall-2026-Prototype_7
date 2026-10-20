using UnityEngine;
using UnityEngine.InputSystem;

public class GridPlayer : MonoBehaviour
{
    public float gridSize = 1f;

    private IslandTile currentIsland;

    void Start()
    {
        FindCurrentIsland();
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Move(Vector2.up);
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Move(Vector2.down);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Move(Vector2.left);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            Move(Vector2.right);
        }
    }

    void Move(Vector2 direction)
    {
        Vector2 newPosition =
            (Vector2)transform.position + direction * gridSize;

        // Check if there is an island there
        Collider2D islandCollider =
            Physics2D.OverlapCircle(newPosition, 0.2f);

        if (islandCollider != null)
        {
            IslandTile newIsland =
                islandCollider.GetComponent<IslandTile>();

            if (newIsland != null)
            {
                // Damage the island we are leaving
                if (currentIsland != null)
                {
                    currentIsland.DamageIsland();
                }

                // Move player
                transform.position = newPosition;

                currentIsland = newIsland;

                // Check if this is the stable island
                if (currentIsland.isStable)
                {
                    IslandGameManager.instance.WinGame();
                }
            }
        }
    }

    void FindCurrentIsland()
    {
        Collider2D islandCollider =
            Physics2D.OverlapCircle(transform.position, 0.2f);

        if (islandCollider != null)
        {
            currentIsland =
                islandCollider.GetComponent<IslandTile>();
        }
    }
}

