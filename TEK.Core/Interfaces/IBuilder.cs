namespace TEK.Core.Interfaces
{
    public interface IBuilder<in TSource, out TOut>
    {
        TOut Build(TSource source);
    }

    public interface IBuilder<in TSource, in TSource2, out TOut>
    {
        TOut Build(TSource source, TSource2 source2);
    }

    public interface IBuilder<in TSource, in TSource2, in TSource3, out TOut>
    {
        TOut Build(TSource source, TSource2 source2, TSource3 source3);
    }

    public interface IBuilder<in TSource, in TSource2, in TSource3, in TSource4, out TOut>
    {
        TOut Build(TSource source, TSource2 source2, TSource3 source3, TSource4 source4);
    }

    public interface IBuilder<out TOut>
    {
        TOut Build();
    }
}
