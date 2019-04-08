using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ObjPooler
{
    public abstract class GenericObjectPool<T>:MonoBehaviour  where T:Component
    {
        [SerializeField] T Prefab;
        private static GenericObjectPool<T> _instance;
        public static GenericObjectPool<T> Instance { get { return _instance; } private set { } }
        private Queue<T> objects;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);

            }
        }
        private T GetObjFromPool()
        {
            if (objects.Count == 0)
                AddObjects(1);
            return objects.Dequeue();
        }

        private void AddObjects(int v)
        {
            for (int i = 0; i < v; i++)
            {
                var newObj = GameObject.Instantiate(Prefab);
                newObj.gameObject.SetActive(false);
                objects.Enqueue(newObj);
            }
        }
    }

}
