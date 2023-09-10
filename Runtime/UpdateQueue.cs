using System;
using System.Collections.Generic;

namespace Paper
{
    public class UpdateQueue
    {
        private static UpdateQueue _instance;
        private static readonly object _lock = new object();

        private UpdateQueue() { }

        public static UpdateQueue Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UpdateQueue();
                    }
                    return _instance;
                }
            }
        }

        public Queue<Update> updates = new();

        public Update GetUpdate()
        {
            if (updates.Count == 0)
            {
                return null;
            }

            return updates.Dequeue();
        }

        public void ScheduleUpdateAfterStateChange(StatelessComponent component)
        {
            updates.Enqueue(new Update(component, UpdatePriority.High));
        }
    }

    [Serializable]
    public class Update
    {
        public readonly StatelessComponent component;
        public readonly UpdatePriority priority;

        public Update(StatelessComponent component, UpdatePriority priority)
        {
            this.component = component;
            this.priority = priority;
        }
    }

    public enum UpdatePriority
    {
        Sync = 40,
        Task = 30,
        High = 20,
        Low = 10,
    }
}
