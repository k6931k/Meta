using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f; //하이와 로우는 옵스타크가 얼마나 상하로 이동 할 것인지
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    GameManager gameManager;

    public float widthPadding = 4f;    // 이 오브젝트들을 배치할 때 사이에 폭을 어느정도로 세팅할지 정함

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)//1. 엑시트를 진행한게
    {
        Player player = collision.GetComponent<Player>();//2. 플레이어라면
        if (player != null)
            gameManager.AddScore(1);//3. 스코어를 올리겠다
    }
}
