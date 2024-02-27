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

        // �Q�[���J�n���͎����I�ɃX�^�[�g�n�_�ɔz�u
        transform.position = targets[num].transform.position;
    }

    void Update() {
        // �w�肳�ꂽ�|�C���g�Ɍ�����ς���
        transform.LookAt(targets[num].transform);

        // �x�N�g���̌v�Z
        moveDirection = targets[num].transform.position - transform.position;

        controller.SimpleMove(moveDirection * speed);

        // �ړI�n�ɋ߂Â�����A���̃|�C���g�ɐ؂�ւ���B
        if (Vector3.Distance(transform.position, targets[num].transform.position) < 1.5f) {
            // ������̃e�N�j�b�N
            num = (num + 1) % targets.Length;
        }
    }
}