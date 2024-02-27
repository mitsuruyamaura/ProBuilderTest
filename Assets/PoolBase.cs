using System;
using UnityEngine.Pool;

/// <summary>
/// オブジェクトプールの Get メソッドの戻り値を PooledObjectClass に変更したクラス
/// </summary>
/// <typeparam name="T"></typeparam>
public class PoolBase<T> : IDisposable where T : class {

    private readonly ObjectPool<T> _pool;
    private int _countInactive;


    /// <summary>
    /// コンストラクタ
    /// 内部で ObjectPool の初期化を行う形でラップしている
    /// </summary>
    /// <param name="createFunc"></param>
    /// <param name="actionOnGet"></param>
    /// <param name="actionOnRelease"></param>
    /// <param name="actionOnDestroy"></param>
    /// <param name="collectionCheck"></param>
    /// <param name="maxSize"></param>
    public PoolBase(
        Func<T> createFunc,
        Action<T> actionOnGet = null,
        Action<T> actionOnRelease = null,
        Action<T> actionOnDestroy = null,
        bool collectionCheck = true,
        int maxSize = 10000) {
        _pool = new ObjectPool<T>(
            createFunc: createFunc,
            actionOnGet: actionOnGet,
            actionOnRelease: actionOnRelease,
            actionOnDestroy: actionOnDestroy,
            collectionCheck: collectionCheck,
            maxSize: maxSize);
    }

    /// <summary>
    /// 通常の Get メソッドの代わりに使い、PooledObject 構造体ではなく PooledObjClass クラスを取得する
    /// タプルにより、また生成したオブジェクトの情報も取得する
    /// </summary>
    /// <returns></returns>
    public (PooledObjClass<T> pooledObject, T obj) Get() {
        T value = _pool.Get();
        return (new PooledObjClass<T>(value, _pool), value);
    }

    /// <summary>
    /// IDisposable の Dispose を実行することでオブジェクトをプールに返却できる
    /// オブジェクト自体がオブジェクトプールへの依存関係を持たないように設計できる
    /// </summary>
    public void Dispose() {
        _pool.Dispose();
    }

    public void Release(T element) {
        _pool.Release(element);
    }

    public void Clear() {
        _pool.Clear();
    }

    public int CountInactive => _countInactive;
}