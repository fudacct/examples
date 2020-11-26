using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(50);
            bt.Insert(20);
            bt.Insert(80);
            bt.Insert(10);
            bt.Insert(30);
            bt.Insert(60);
            bt.Insert(90);
            bt.Insert(25);
            bt.Insert(85);
            bt.Insert(100);
            bt.PrintTree(bt._root, 0, "root", 10);
            bt.RemoveTree(10);//删除没有子节点的节点
            bt.RemoveTree(30);//删除有一个子节点的节点
            bt.RemoveTree(80);//删除有两个子节点的节点
            Console.WriteLine("--------------------------------------------------------------");
            bt.PrintTree(bt._root, 0, "root", 10);
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("最大值:" + bt.FindMax().Item);
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("最小值:" + bt.FindMin().Item);
            Console.WriteLine("--------------------------------------------------------------");

        }
    }

    public class Node
    {
        public int Item { set; get; }   //节点数据
        public Node LeftChild { set; get; } //左子节点的引用
        public Node RightChild { set; get; } //右子节点的引用
        public bool IsDelete { set; get; }//表示节点是否被删除

        public Node(int data)
        {
            this.Item = data;
        }
    }

    public class BinaryTree
    {
        //表示根节点
        public Node _root;

        public void PrintTree(Node head, int height, string to, int len)
        {
            if (head == null)
            {
                return;
            }
            PrintTree(head.RightChild, height + 1, "right", len);
            string val = to + "\"" + head.Item + "\"" + to;
            int lenM = val.Length;
            int lenL = (len - lenM) / 2;
            int lenR = len - lenM - lenL;
            val = GetSpace(lenL) + val + GetSpace(lenR);
            Console.WriteLine(GetSpace(height * len) + val);
            PrintTree(head.LeftChild, height + 1, "left", len);
        }

        public string GetSpace(int num)
        {
            string space = " ";
            StringBuilder buf = new StringBuilder("");
            for (int i = 0; i < num; i++)
            {
                buf.Append(space);
            }
            return buf.ToString();
        }

        //查找节点
        public Node Find(int key)
        {
            Node current = _root;
            while (current != null)
            {
                if (current.Item > key)
                {//当前值比查找值大，搜索左子树
                    current = current.LeftChild;
                }
                else if (current.Item < key)
                {//当前值比查找值小，搜索右子树
                    current = current.RightChild;
                }
                else
                {
                    return current;
                }
            }
            return null;//遍历完整个树没找到，返回null
        }

        //插入节点
        public bool Insert(int data)
        {
            Node newNode = new Node(data);
            if (_root == null)
            {//当前树为空树，没有任何节点
                _root = newNode;
                return true;
            }
            else
            {
                Node current = _root;
                Node parentNode = null;
                while (current != null)
                {
                    parentNode = current;
                    if (current.Item > data)
                    {//当前值比插入值大，搜索左子节点
                        current = current.LeftChild;
                        if (current == null)
                        {//左子节点为空，直接将新值插入到该节点
                            parentNode.LeftChild = newNode;
                            return true;
                        }
                    }
                    else
                    {
                        current = current.RightChild;
                        if (current == null)
                        {//右子节点为空，直接将新值插入到该节点
                            parentNode.RightChild = newNode;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //中序遍历
        public void InfixOrder(Node current)
        {
            if (current != null)
            {
                InfixOrder(current.LeftChild);
                Console.WriteLine(current.Item + " ");
                InfixOrder(current.RightChild);
            }
        }

        //前序遍历
        public void PreOrder(Node current)
        {
            if (current != null)
            {
                Console.WriteLine(current.Item + " ");
                InfixOrder(current.LeftChild);
                InfixOrder(current.RightChild);
            }
        }

        //后序遍历
        public void PostOrder(Node current)
        {
            if (current != null)
            {
                InfixOrder(current.LeftChild);
                InfixOrder(current.RightChild);
                Console.WriteLine(current.Item + " ");
            }
        }
        //找到最大值
        public Node FindMax()
        {
            Node current = _root;
            Node maxNode = current;
            while (current != null)
            {
                maxNode = current;
                current = current.RightChild;
            }
            return maxNode;
        }
        //找到最小值
        public Node FindMin()
        {
            Node current = _root;
            Node minNode = current;
            while (current != null)
            {
                minNode = current;
                current = current.LeftChild;
            }
            return minNode;
        }

        public bool RemoveTree(int key)
        {
            Node current = _root;
            Node parent = _root;
            bool isLeftChild = false;
            //查找删除值，找不到直接返回false
            while (current.Item != key)
            {
                parent = current;
                if (current.Item > key)
                {
                    isLeftChild = true;
                    current = current.LeftChild;
                }
                else
                {
                    isLeftChild = false;
                    current = current.RightChild;
                }
                if (current == null)
                {
                    return false;
                }
            }
            //如果当前节点没有子节点
            if (current.LeftChild == null && current.RightChild == null)
            {
                if (current == _root)
                {
                    _root = null;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }
                return true;

                //当前节点有一个子节点，右子节点
            }
            else if (current.LeftChild == null && current.RightChild != null)
            {
                if (current == _root)
                {
                    _root = current.RightChild;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = current.RightChild;
                }
                else
                {
                    parent.RightChild = current.RightChild;
                }
                return true;
                //当前节点有一个子节点，左子节点
            }
            else if (current.LeftChild != null && current.RightChild == null)
            {
                if (current == _root)
                {
                    _root = current.LeftChild;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = current.LeftChild;
                }
                else
                {
                    parent.RightChild = current.LeftChild;
                }
                return true;
            }
            else
            {
                //当前节点存在两个子节点
                Node successor = GetSuccessor(current);
                if (current == _root)
                {
                    successor = _root;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = successor;
                }
                else
                {
                    parent.RightChild = successor;
                }
                successor.LeftChild = current.LeftChild;
            }
            return false;

        }

        private Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.RightChild;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.LeftChild;
            }
            //后继节点不是删除节点的右子节点，将后继节点替换删除节点
            if (successor != delNode.RightChild)
            {
                successorParent.LeftChild = successor.RightChild;
                successor.RightChild = delNode.RightChild;
            }
            return successor;
        }
    }

}
