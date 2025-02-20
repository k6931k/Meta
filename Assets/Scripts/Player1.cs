using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; // �ٸ� Scene�� ����ϰ� ����
public class Player1 : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private bool isNearMini = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearMini && Input.GetKeyDown(KeyCode.F)) //FŰ�� ������ ����ǰ� �ߴ�.
        {
            SceneManager.LoadScene("SampleScene");
        }

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mini")) // ��� ���ӱ⿡�� �۵��� �� �ֵ��� �±׸� �����ߴ�.
        {
            isNearMini = true;
        }
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
