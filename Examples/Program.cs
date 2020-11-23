using System;

namespace Examples
{
    class Program
    {
        /// <summary>
        /// 合并链表
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //链表1
            ListNode listNode13 = new ListNode(4);
            ListNode listNode12 = new ListNode(2, listNode13);
            ListNode listNode11 = new ListNode(1, listNode12);
            //链表2
            ListNode listNode23 = new ListNode(4);
            ListNode listNode22 = new ListNode(3, listNode23);
            ListNode listNode21 = new ListNode(1, listNode22);

            Solution solution = new Solution();
            Console.WriteLine("链表1");
            solution.Print(listNode11);
            Console.WriteLine("链表2");
            solution.Print(listNode21);
            Console.WriteLine("合并链表1，链表2");
            ListNode result = solution.mergeTwoLists(listNode11, listNode21);
            solution.Print(result);


            Console.ReadKey();
        }

        
    }



    /// <summary>
    /// 定义链表结构
    /// </summary>
    //Definition for singly-linked list.						
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode() { }
        public ListNode(int val) { this.val = val; }
        public ListNode(int val, ListNode next) { this.val = val; this.next = next; }
    }
    /// <summary>
    /// 合并链表解决方案
    /// </summary>
    class Solution
    {
        /// <summary>
        /// 合并两个链表
        /// </summary>
        /// <param name="l1">链表1</param>
        /// <param name="l2">链表2</param>
        /// <returns></returns>
        public ListNode mergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            else if (l2 == null) return l1;
            else if (l1.val < l2.val)
            {
                l1.next = mergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = mergeTwoLists(l2.next, l1);
                return l2;
            }
        }
        /// <summary>
        /// 打印链表
        /// </summary>
        /// <param name="node">两边</param>
        public void Print(ListNode node)
        {
            Console.WriteLine(node.val);
            if (node.next == null)
                return;
            else
            {
                Print(node.next);
            }
        }
    }


}
