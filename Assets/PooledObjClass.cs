using System;

namespace UnityEngine.Pool {

    public class PooledObjClass<T> : IDisposable where T : class {

        private readonly T m_ToReturn;
        private readonly IObjectPool<T> m_Pool;

        public PooledObjClass(T value, IObjectPool<T> pool) {
            m_ToReturn = value;
            m_Pool = pool;
        }

        public void Dispose() => m_Pool.Release(m_ToReturn);
    }
}
