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
        public Queue<T> objects;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                objects = new Queue<T>();
                DontDestroyOnLoad(this.gameObject);

            }
        }
        public T GetObjFromPool(Transform transform)
        {
            if (objects.Count == 0)
                AddObjects(4);

            T obj = objects.Dequeue();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.gameObject.SetActive(true);
            return obj ;
        }

        private void AddObjects(int v)
        {
            for (int i = 0; i < v; i++)
            {
                var newObj = GameObject.Instantiate(Prefab);
                newObj.gameObject.SetActive(false);
                newObj.transform.parent=transform;
                objects.Enqueue(newObj);
            }
        }
        public void ReturnToPool(T gameObjectReturnPool)
        {
            gameObjectReturnPool.gameObject.SetActive(false);
            objects.Enqueue(gameObjectReturnPool);
        }
    }

}
