using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infinity.System
{
    public class ObjectPool : MonoBehaviour
    {

        private static readonly Dictionary<GameObject, Pool> pools = new Dictionary<GameObject, Pool>();
        private static readonly Dictionary<GameObject, Component> components = new Dictionary<GameObject, Component>();
        
        private static Transform poolContainer;
        private static Transform spawnContainer;

        private void Awake()
        {
            if (poolContainer != null)
                Destroy(gameObject);

            poolContainer = transform;
        }

        public static void SetContainer(ObjectContainer objectContainer) {
            spawnContainer = objectContainer.transform;
        }

        public static T SpawnPoolObject<T>(T original, Vector2 position = default, Quaternion rotation = default, Transform parent = null) where T : Component
        {
            if (parent == null) {
                parent = spawnContainer;
            }

            if (!pools.ContainsKey(original.gameObject))
            {
                Pool createdPool = new Pool(original.name, poolContainer);
                T instance = Instantiate(original, position, rotation, parent);
                
                pools[original.gameObject] = createdPool;
                pools[instance.gameObject] = createdPool;
                createdPool.AddActiveInstance(instance);

                components[instance.gameObject] = instance;
                return instance;
            }

            Pool pool = pools[original.gameObject];

            if (pool.AvailableInstances > 0)
            {
                Component poolComponent = pool.GetFromPool();
                T component = poolComponent as T;

                if (component == null)
                    component = poolComponent.GetComponent<T>();

                component.transform.SetPositionAndRotation(position, rotation);
                component.transform.SetParent(parent);
                component.gameObject.SetActive(true);

                return component;
            }
            else
            {
                T component = Instantiate(original, position, rotation, parent);
                GameObject componentGameObject = component.gameObject;
                components[componentGameObject] = component;
                pools[componentGameObject] = pool;
                pool.AddActiveInstance(component);
                return component;
            }
        }

        public static void ReturnToPool<T>(T instance) where T : Component
        {
            if (pools.ContainsKey(instance.gameObject))
            {
                pools[instance.gameObject].AddToPool(components[instance.gameObject]);
                return;
            }

            GameObject instanceGameObject = instance.gameObject;
            components[instanceGameObject] = instance;
            Pool pool = new Pool(instance.name, poolContainer);
            pools[instanceGameObject] = pool;
            pool.AddToPool(instance);
        }

        public static void ReturnAllToPool()
        {
            foreach(Pool pool in pools.Values.ToList())
            {
                foreach (Component instance in pool.ActiveInstances.ToList())
                    pool.AddToPool(instance);
            }
        }
    }
}
