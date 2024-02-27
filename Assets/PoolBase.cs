using System;
using UnityEngine.Pool;

/// <summary>
/// �I�u�W�F�N�g�v�[���� Get ���\�b�h�̖߂�l�� PooledObjectClass �ɕύX�����N���X
/// </summary>
/// <typeparam name="T"></typeparam>
public class PoolBase<T> : IDisposable where T : class {

    private readonly ObjectPool<T> _pool;
    private int _countInactive;


    /// <summary>
    /// �R���X�g���N�^
    /// ������ ObjectPool �̏��������s���`�Ń��b�v���Ă���
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
    /// �ʏ�� Get ���\�b�h�̑���Ɏg���APooledObject �\���̂ł͂Ȃ� PooledObjClass �N���X���擾����
    /// �^�v���ɂ��A�܂����������I�u�W�F�N�g�̏����擾����
    /// </summary>
    /// <returns></returns>
    public (PooledObjClass<T> pooledObject, T obj) Get() {
        T value = _pool.Get();
        return (new PooledObjClass<T>(value, _pool), value);
    }

    /// <summary>
    /// IDisposable �� Dispose �����s���邱�ƂŃI�u�W�F�N�g���v�[���ɕԋp�ł���
    /// �I�u�W�F�N�g���̂��I�u�W�F�N�g�v�[���ւ̈ˑ��֌W�������Ȃ��悤�ɐ݌v�ł���
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