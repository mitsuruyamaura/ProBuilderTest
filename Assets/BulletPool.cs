using System;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    private IObjectPool<Bullet> _bulletPool;

    [SerializeField] private Bullet bulletPrefab;


    private void Awake() {
        _bulletPool = new ObjectPool<Bullet>
            (
                createFunc: CreateBullet,
                actionOnGet: bullet => bullet.gameObject.SetActive(true),
                actionOnRelease: bullet => Release(bullet),
                actionOnDestroy: bullet => Destroy(bullet.gameObject)
            );
    }

    private void Update() {
        if (_bulletPool == null) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            GetBullet();
        }
    }

    public Bullet GetBullet() {
        
        // �ʏ�̕��@
        //Bullet bullet = _bulletPool.Get();
        //bullet.BulletPool = this;

        //out�C���q��bullet�����o���A�Ԃ�l��IDisposable�Ƃ��Ď擾����
        IDisposable disposable = _bulletPool.Get(out var bullet);

        // �擾����bullet�̃C���X�^���X�ɁA�v�[���ւ̕ԋp�@�\��n��
        // ���_�� Bullet ���ɂ� IDisposable �̂ݗp�ӂ���΂悢����(���� Objectpool �̌^���ς���Ă��e�����Ȃ�)
        bullet.SetReturner(disposable);

        // �Ăяo������Bullet�̃C���X�^���X��Ԃ�
        return bullet;
    }

    /// <summary>
    /// createFunc �̃R�[���o�b�N
    /// Get �Ŏ��s�����
    /// </summary>
    /// <returns></returns>
    private Bullet CreateBullet() {
        Bullet bullet = Instantiate(bulletPrefab);
        return bullet;
    }

    /// <summary>
    /// actionOnRelease �̃R�[���o�b�N
    /// Release �Ŏ��s�����
    /// </summary>
    /// <param name="bullet"></param>
    public void Release(Bullet bullet) {
        if (!bullet.gameObject.activeInHierarchy) {
            return;
        }
        bullet.gameObject.SetActive (false);
        Debug.Log("Release");
    }
}