using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MugenMap : MonoBehaviour
{
    public GameObject grid; // Grid 오브젝트
    public Transform player; // 플레이어의 Transform
    private Vector3Int playerGridPosition;
    private Vector3Int lastPlayerGridPosition;

    private Vector2 tilemapSize; // 타일맵 크기

    void Start()
    {
        var tile = grid.transform.GetChild(0);
        tilemapSize = CalculateTileSize(tile.GetComponent<Tilemap>());

        // 타일맵 복사 및 5x5 타일맵 생성
        for (int i = 0; i < 25; i++)
        {
            Instantiate(tile).transform.SetParent(grid.transform);
        }

        int index = 0;

        // 타일맵을 더 넓게 배치 (5x5)
        for (float x = -2 * tilemapSize.x; x <= 2 * tilemapSize.x; x += tilemapSize.x)
        {
            for (float y = -2 * tilemapSize.y; y <= 2 * tilemapSize.y; y += tilemapSize.y)
            {
                grid.transform.GetChild(index++).position = new Vector3(x, y, 0);
            }
        }

        // 플레이어를 중앙 타일맵의 중앙에 위치시키기
        player.position = Vector3.zero;

        // 초기 플레이어 위치 저장
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