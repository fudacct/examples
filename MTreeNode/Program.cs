using System;
using System.Collections.Generic;
using System.IO;

namespace MTreeNode
{
    public class MTreeNode
    {
        private string _name;//节点名  
        private int _nChildren;//子节点数  
        private int _level = -1;// 记录该节点在多叉树中的层数  
        List<MTreeNode> _children;// 指向其自身的子节点，children一个链表，该链表中的元素是MTreeNode类型的指针  

        public MTreeNode()
        {
            _children = new List<MTreeNode>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int NChildren
        {
            get { return _nChildren; }
            set { _nChildren = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public List<MTreeNode> Children
        {
            get { return _children; }
            set { _children = value; }
        }
    }

    public class MultiTree
    {
        private Stack<MTreeNode> t_stack;
        private Queue<MTreeNode> queue_t = new Queue<MTreeNode>();


        /// <summary>  
        /// 深度优先遍历查找  
        /// </summary>  
        /// <param name="name">查找内容</param>  
        /// <param name="head">当前节点（从首节点开始）</param>  
        /// <returns>目标节点</returns>  
        private static MTreeNode search_node_r(string name, MTreeNode head)
        {
            MTreeNode temp = null;
            if (head != null)
            {
                if (name.Equals(head.Name))
                {
                    temp = head; //如果名字匹配  
                }
                else //如果不匹配，则查找其子节点  
                {
                    for (int i = 0; i < head.NChildren && temp == null; i++)
                    {
                        temp = search_node_r(name, head.Children[i]);
                    }
                }
            }
            return temp;
        }

        /// <summary>  
        /// 从文件中读取多叉树数据，并建立多叉树  
        /// </summary>  
        /// <param name="head">多叉树根节点</param>  
        /// <param name="filePath">文件路径</param>  
        public static void read_file(ref MTreeNode head, string filePath)
        {
            MTreeNode temp = null;
            int n;
            string name, child;
            using (StreamReader sr = new StreamReader(filePath))
            {
                //一行行读取直至为NULL  
                string strLine = string.Empty;
                while ((strLine = sr.ReadLine()) != null)
                {
                    string[] strings = strLine.Split(' ');
                    name = strings[0];
                    n = int.Parse(strings[1]);
                    if (head == null) //若为空  
                    {
                        //让temp和head引用同一块内存空间  
                        temp = head = new MTreeNode(); //生成一个新节点  
                        temp.Name = name; //赋名  
                    }
                    else
                    {
                        temp = search_node_r(name, head);
                        //这里默认数据文件是正确的，一定可以找到与name匹配的节点  
                        //如果不匹配，那么应该忽略本行数据  
                    }
                    //找到节点后，对子节点进行处理  
                    temp.NChildren = n;
                    for (int i = 0; i < n; i++)
                    {
                        child = strings[i + 2];
                        temp.Children.Add(new MTreeNode());
                        temp.Children[i].Name = child;
                    }
                }
            }

        }

        /// <summary>  
        /// 实现函数1  
        /// 将多叉树中的节点，按照深度进行输出  
        /// 实质上实现的是层次优先遍历  
        /// </summary>  
        /// <param name="head">首节点</param>  
        private static void f1(MTreeNode head)
        {
            MTreeNode tMTreeNode;
            Queue<MTreeNode> queue = new Queue<MTreeNode>(100); //将队列初始化大小为100  
            Stack<MTreeNode> stack = new Stack<MTreeNode>(100); //将栈初始化大小为100  
            head.Level = 0; //根节点的深度为0  

            //将根节点入队列  
            queue.Enqueue(head);

            //对多叉树中的节点的深度值level进行赋值  
            //采用层次优先遍历方法，借助于队列  
            while (queue.Count != 0) //如果队列q不为空  
            {
                tMTreeNode = queue.Dequeue(); //出队列  
                for (int i = 0; i < tMTreeNode.NChildren; i++)
                {
                    tMTreeNode.Children[i].Level = tMTreeNode.Level + 1; //对子节点深度进行赋值：父节点深度加1  
                    queue.Enqueue(tMTreeNode.Children[i]); //将子节点入队列  
                }
                stack.Push(tMTreeNode); //将p入栈  
            }

            while (stack.Count != 0) //不为空  
            {
                tMTreeNode = stack.Pop(); //弹栈  
                System.Diagnostics.Debug.WriteLine("   {0} {1}", tMTreeNode.Level, tMTreeNode.Name);
            }
        }

        /// <summary>  
        /// 实现函数2  
        /// 找到从根节点到叶子节点路径上节点名字字母个数最大的路径  
        /// 实质上实现的是深度优先遍历  
        /// </summary>  
        /// <param name="head">首节点</param>  
        /// <param name="str">临时字符串</param>  
        /// <param name="strBest">从根节点到叶子节点路径上节点名字字母个数最大的路径</param>  
        /// <param name="level">当前深度</param>  
        private static void f2(MTreeNode head, string str, ref string strBest, int level)
        {
            if (head == null) return;
            var tmp = str + head.Name;

            if (head.NChildren == 0)
            {
                if (strBest == null || tmp.Length > strBest.Length)
                {
                    strBest = tmp;
                }
            }
            for (var i = 0; i < head.NChildren; i++)
            {
                f2(head.Children[i], tmp, ref strBest, level + 1);
            }
        }

        private void free_tree_r(MTreeNode head)
        {
            if (head == null)
                return;
            head = null;
        }

        static void Main(string[] args)
        {
            MTreeNode head = null;
            string strBest = null;
            read_file(ref head, "TextFile1.txt");
            System.Diagnostics.Debug.WriteLine("f1:");
            f1(head);
            f2(head, "", ref strBest, 0);
            System.Diagnostics.Debug.WriteLine("f2:\n   {0}", strBest);
            Console.ReadKey();
        }
    }
}
