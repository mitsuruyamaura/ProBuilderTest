using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] targets;
    public float speed;
    private int num = 0;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start() {
        controller = GetComponent<CharacterController>();

        // ゲーム開始時は自動的にスタート地点に配置
        transform.position = targets[num].transform.position;
    }

    void Update() {
        // 指定されたポイントに向きを変える
        transform.LookAt(targets[num].transform);

        // ベクトルの計算
        moveDirection = targets[num].transform.position - transform.position;

        controller.SimpleMove(moveDirection * speed);

        // 目的地に近づいたら、次のポイントに切り替える。
        if (Vector3.Distance(transform.position, targets[num].transform.position) < 1.5f) {
            // 順送りのテクニック
            num = (num + 1) % targets.Length;
        }
    }
}