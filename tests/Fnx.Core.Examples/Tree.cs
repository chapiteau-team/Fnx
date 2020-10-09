using Fnx.Core.Types;

namespace Fnx.Core.Examples
{
    public readonly struct TreeF
    {
    }

    public abstract class Tree<T> : IKind<TreeF, T>
    {
    }

    public class Branch<T> : Tree<T>
    {
        private readonly Tree<T> _left;
        private readonly Tree<T> _right;

        public Branch(Tree<T> left, Tree<T> right)
        {
            _left = left;
            _right = right;
        }

        public void Deconstruct(out Tree<T> left, out Tree<T> right)
        {
            left = _left;
            right = _right;
        }

        public override string ToString() => $"Branch({_left}, {_right})";
    }

    public class Leaf<T> : Tree<T>
    {
        private readonly T _value;

        public Leaf(T value)
        {
            _value = value;
        }

        public void Deconstruct(out T value)
        {
            value = _value;
        }

        public override string ToString() => $"Leaf({_value})";
    }

    public static class Tree
    {
        public static Tree<T> Fix<T>(this IKind<TreeF, T> self) => (Tree<T>) self;
    }
}