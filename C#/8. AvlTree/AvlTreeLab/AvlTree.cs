namespace AvlTreeLab
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class AvlTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public void Add(T item)
        {
            var inserted = true;
            if (this.root == null)
            {
                this.root = new Node<T>(item);
            }
            else
            {
                inserted = this.InsertInternal(this.root, item);
            }

            if (inserted)
            {
                this.Count++;
            }
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            
            while (true)
            {
                if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        this.RetraceInsert(newNode);
                        return true;
                    }
                    currentNode = currentNode.RightChild;
                }
                else if (currentNode.Value.CompareTo(item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        this.RetraceInsert(newNode);
                        return true;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    return false;
                }
            }
        }

        private void RetraceInsert(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor++;
                        if (node.BalanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }

                        this.RotateRight(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = 1;
                    }
                }
                else
                {
                    if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor--;
                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }
                        this.RotateLeft(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = -1;
                    }
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateRight(Node<T> node)
        {
            var parent= node.Parent;
            var child = node.LeftChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }
            node.LeftChild = child.RightChild;
            child.RightChild = node;

            node.BalanceFactor -= 1 + Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Min(node.BalanceFactor, 0);
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }
            node.RightChild = child.LeftChild;
            child.LeftChild = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(node.BalanceFactor, 0);
        }

        public bool Contains(T item)
        {
           return this.Find(item) != null;
        }

        private Node<T> Find(T item)
        {
            var node = this.root;

            while (node!=null)
            {
                if (node.Value.CompareTo(item) == 0)
                {
                    return node;
                }

                if (node.Value.CompareTo(item) < 0)
                {
                    node = node.RightChild;
                }

                else
                {
                    node = node.LeftChild;
                }
            }

            return null;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (Count==0)
            {
                return;
            }

            this.InOrderDfs(this.root, 1, action);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                this.InOrderDfs(node.LeftChild, depth + 1, action);
            }

            action(depth, node.Value);

            if (node.RightChild !=null)
            {
                this.InOrderDfs(node.RightChild, depth + 1, action);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var nodes = new Stack<Node<T>>();
            var currentNode = this.root;
            var done = false;
            while (!done)
            {
                if (currentNode != null)
                {
                    nodes.Push(currentNode);
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    if (nodes.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        var top = nodes.Pop();
                        yield return top.Value;

                        currentNode = top.RightChild;
                    }
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
