using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Dispose メソッドを利用しない場合には、IDisposable インターフェースを実装せずに
    // メンバ変数として IDisposable を用意すれば、このクラスは IDisposable データ型として認識される
    private IDisposable _disposable;

    // 従来の実装方法
    //private BulletPool bulletPool;
    //public BulletPool BulletPool { get => bulletPool; set => bulletPool = value; }


    /// <summary>
    /// 依存関係ではなく、IDisposable として情報をもらうことで生成クラスを知る必要がない
    /// </summary>
    /// <param name="disposable"></param>
    public void SetReturner(IDisposable disposable) {
        //外部からこのメソッドを叩くことで、返却機能を登録できるようにする
        _disposable = disposable;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            // disposeを呼ぶだけで返却される = ObjectPool の Release が自動的に呼ばれる
            _disposable.Dispose();

            //ReturnPool();
        }

    }

    /// <summary>
    /// 従来の戻し方
    /// </summary>
    //public void ReturnPool() {
    //    bulletPool.Release(this);
    //}
}
