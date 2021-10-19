using System.Collections.Generic;
using UnityEngine;

namespace Infinity.System
{
    public class Pool
    {
        public int AvailableInstances => pool.Count;
        public Transform Container { get; }
        public List<Component> ActiveInstances { get; } = new List<Component>();

        private readonly Queue<Component> pool = new Queue<Component>();

        public Pool(string name, Transform poolContainer)
        {
            Container = new GameObject($"[{name} Container]").transform;
            Container.SetParent(poolContainer);
        }

        public Component GetFromPool()
        {
            Component component = null;
            
            while (component == null && AvailableInstances > 0)
                component = pool.Dequeue();

            if (component != null)
            {
                ActiveInstances.Add(component);
            }

            return component;
        }

        public void AddToPool(Component component)
        {
            if (ActiveInstances.Contains(component))
                ActiveInstances.Remove(component);

            pool.Enqueue(component);
            component.gameObject.transform.SetParent(Container);
            component.gameObject.SetActive(false);
        }

        public void AddActiveInstance(Component component)
        {
            ActiveInstances.Add(component);
        }
    }
}
