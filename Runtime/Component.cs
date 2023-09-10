namespace Paper
{
    public abstract class Component<T> : StatelessComponent
    {
        protected T state;

        protected void SetState(T state)
        {
            this.state = state;

            UpdateQueue.Instance.ScheduleUpdateAfterStateChange(this);
        }
    }
}
