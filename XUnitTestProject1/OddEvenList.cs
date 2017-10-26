using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
  public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
 }

    class OddEvenListTest
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return null;
            var oddHead = head;
            var evenHead = head.next;
            var cur = head;
            var oddtail = head;
            var i = 0;
            while (cur.next != null)
            {
                var n = cur.next;
                i++;

                if (cur.next.next != null && i % 2 == 1)
                {
                    oddtail = cur.next.next;
                }
                cur.next = cur.next.next;
                cur = n;

            }
            oddtail.next = evenHead;
            return oddHead;
        }
    }
}
