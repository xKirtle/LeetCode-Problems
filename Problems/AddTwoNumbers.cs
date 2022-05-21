using System.Numerics;

namespace LeetCode.Problems;

public class AddTwoNumbers : BaseProblem
{
    public AddTwoNumbers() => SetProblemStats(2, "Add Two Numbers", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1
        ListNode l1 = arrayToListNode(new[] {2, 4, 3});
        ListNode l2 = arrayToListNode(new[] {5, 6, 4});
        printListNode(SolveAddTwoNumbers(l1, l2), 1);
        
        //Example 2
        l1 = new ListNode(0);
        l2 = new ListNode(0);
        printListNode(SolveAddTwoNumbers(l1, l2), 2);
        
        //Example 3
        l1 = arrayToListNode(new[] {9, 9, 9, 9, 9, 9, 9});
        l2 = arrayToListNode(new[] {9, 9, 9, 9});
        printListNode(SolveAddTwoNumbers(l1, l2), 3);

        ListNode arrayToListNode(int[] arr)
        {
            ListNode listNode = new ListNode();
            ListNode rootNode = listNode;
            for (int i = 0; i < arr.Length; i++)
            {
                listNode.val = arr[i];
                listNode.next = new ListNode();
                listNode = listNode.next;
            }

            return rootNode;
        }
            
        void printListNode(ListNode listNode, int exampleNum)
        {
            List<int> result = new List<int>();
            while (listNode.next != null)
            {
                result.Add(listNode.val);
                listNode = listNode.next;
            }
            
            Console.WriteLine($"Example {exampleNum}: [{String.Join(", ", result)}]");
        }
    }

    private class ListNode 
    {
         public int val;
         public ListNode next;
         public ListNode(int val = 0, ListNode next = null) 
         {
             this.val = val;
             this.next = next;
         }
    }

    private ListNode SolveAddTwoNumbers(ListNode l1, ListNode l2)
    {
        string ListNodeValuesToString(ListNode listNode)
        {
            string result = "";
            while (listNode.next != null)
            {
                result += listNode.val.ToString();
                listNode = listNode.next;
            }

            return result + listNode.val.ToString();
        }

        string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        //Could shave off a lot of time if I only called ListNodeValuesToString once and used some
        //logic to determine whether l1/l2 could keep going to the next node
        string n1 = ReverseString(ListNodeValuesToString(l1));
        string n2 = ReverseString(ListNodeValuesToString(l2));
        string result = ReverseString((BigInteger.Parse(n1) + BigInteger.Parse(n2)).ToString());

        ListNode listNode = new ListNode();
        ListNode rootNode = listNode;
        for (int i = 0; i < result.Length; i++)
        {
            listNode.val = int.Parse(result[i].ToString());
            listNode.next = new ListNode();
            listNode = listNode.next;
            
            //Because of the way LeetCode handles their print function (hidden)
            // listNode.val = int.Parse(result[i].ToString());
            // if (i != result.Length - 1)
            // {
            //     listNode.next = new ListNode();
            //     listNode = listNode.next;
            // }
        }

        return rootNode;
    }
}