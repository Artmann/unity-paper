namespace Paper
{
    public abstract class StatelessComponent : Renderable
    {
        public abstract Renderable Render();

        public virtual void ComponentDidMount() { }
    }
}
