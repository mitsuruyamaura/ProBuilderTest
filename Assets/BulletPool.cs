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
        
        // 通常の方法
        //Bullet bullet = _bulletPool.Get();
        //bullet.BulletPool = this;

        //out修飾子でbulletを取り出し、返り値をIDisposableとして取得する
        IDisposable disposable = _bulletPool.Get(out var bullet);

        // 取得したbulletのインスタンスに、プールへの返却機能を渡す
        // 利点は Bullet 側には IDisposable のみ用意すればよいこと(仮に Objectpool の型が変わっても影響がない)
        bullet.SetReturner(disposable);

        // 呼び出し側にBulletのインスタンスを返す
        return bullet;
    }

    /// <summary>
    /// createFunc のコールバック
    /// Get で実行される
    /// </summary>
    /// <returns></returns>
    private Bullet CreateBullet() {
        Bullet bullet = Instantiate(bulletPrefab);
        return bullet;
    }

    /// <summary>
    /// actionOnRelease のコールバック
    /// Release で実行される
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