using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Dispose ���\�b�h�𗘗p���Ȃ��ꍇ�ɂ́AIDisposable �C���^�[�t�F�[�X������������
    // �����o�ϐ��Ƃ��� IDisposable ��p�ӂ���΁A���̃N���X�� IDisposable �f�[�^�^�Ƃ��ĔF�������
    private IDisposable _disposable;

    // �]���̎������@
    //private BulletPool bulletPool;
    //public BulletPool BulletPool { get => bulletPool; set => bulletPool = value; }


    /// <summary>
    /// �ˑ��֌W�ł͂Ȃ��AIDisposable �Ƃ��ď������炤���ƂŐ����N���X��m��K�v���Ȃ�
    /// </summary>
    /// <param name="disposable"></param>
    public void SetReturner(IDisposable disposable) {
        //�O�����炱�̃��\�b�h��@�����ƂŁA�ԋp�@�\��o�^�ł���悤�ɂ���
        _disposable = disposable;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            // dispose���ĂԂ����ŕԋp����� = ObjectPool �� Release �������I�ɌĂ΂��
            _disposable.Dispose();

            //ReturnPool();
        }

    }

    /// <summary>
    /// �]���̖߂���
    /// </summary>
    //public void ReturnPool() {
    //    bulletPool.Release(this);
    //}
}
