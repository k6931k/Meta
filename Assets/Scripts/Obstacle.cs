using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f; //���̿� �ο�� �ɽ�Ÿũ�� �󸶳� ���Ϸ� �̵� �� ������
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    GameManager gameManager;

    public float widthPadding = 4f;    // �� ������Ʈ���� ��ġ�� �� ���̿� ���� ��������� �������� ����

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

    private void OnTriggerExit2D(Collider2D collision)//1. ����Ʈ�� �����Ѱ�
    {
        Player player = collision.GetComponent<Player>();//2. �÷��̾���
        if (player != null)
            gameManager.AddScore(1);//3. ���ھ �ø��ڴ�
    }
}
