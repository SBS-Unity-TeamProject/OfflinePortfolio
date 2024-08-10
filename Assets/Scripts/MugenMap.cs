using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MugenMap : MonoBehaviour
{
    public GameObject grid; // Grid ������Ʈ
    public Transform player; // �÷��̾��� Transform
    private Vector3Int playerGridPosition;
    private Vector3Int lastPlayerGridPosition;

    private Vector2 tilemapSize; // Ÿ�ϸ� ũ��

    void Start()
    {
        var tile = grid.transform.GetChild(0);
        tilemapSize = CalculateTileSize(tile.GetComponent<Tilemap>());

        // Ÿ�ϸ� ���� �� 5x5 Ÿ�ϸ� ����
        for (int i = 0; i < 25; i++)
        {
            Instantiate(tile).transform.SetParent(grid.transform);
        }

        int index = 0;

        // Ÿ�ϸ��� �� �а� ��ġ (5x5)
        for (float x = -2 * tilemapSize.x; x <= 2 * tilemapSize.x; x += tilemapSize.x)
        {
            for (float y = -2 * tilemapSize.y; y <= 2 * tilemapSize.y; y += tilemapSize.y)
            {
                grid.transform.GetChild(index++).position = new Vector3(x, y, 0);
            }
        }

        // �÷��̾ �߾� Ÿ�ϸ��� �߾ӿ� ��ġ��Ű��
        player.position = Vector3.zero;

        // �ʱ� �÷��̾� ��ġ ����
        playerGridPosition = GetGridPosition(player.position);
        lastPlayerGridPosition = playerGridPosition;
    }

    Vector2 CalculateTileSize(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int? min = null;
        Vector3Int? max = null;

        foreach (var pos in bounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                if (min == null)
                {
                    min = pos;
                    max = pos;
                }
                else
                {
                    min = Vector3Int.Min(min.Value, pos);
                    max = Vector3Int.Max(max.Value, pos);
                }
            }
        }

        int width = -1;
        int height = -1;

        if (min.HasValue && max.HasValue)
        {
            width = max.Value.x - min.Value.x + 1;
            height = max.Value.y - min.Value.y + 1;
        }

        return new Vector2(width, height);
    }

    void Update()
    {
        playerGridPosition = GetGridPosition(player.position);

        if (Vector3Int.Distance(playerGridPosition, lastPlayerGridPosition) >= 1)
        {
            UpdateTilemaps();
            lastPlayerGridPosition = playerGridPosition;
        }
    }

    Vector3Int GetGridPosition(Vector3 position)
    {
        return new Vector3Int(
            Mathf.RoundToInt(position.x / tilemapSize.x),
            Mathf.RoundToInt(position.y / tilemapSize.y),
            0
        );
    }

    void UpdateTilemaps()
    {
        Vector3Int offset = playerGridPosition - lastPlayerGridPosition;

        foreach (Transform child in grid.transform)
        {
            child.position += new Vector3(offset.x * tilemapSize.x, offset.y * tilemapSize.y, 0);
        }
    }


}