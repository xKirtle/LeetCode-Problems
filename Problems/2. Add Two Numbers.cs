using System.Numerics;
using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class AddTwoNumbers : BaseProblem
{
    public AddTwoNumbers() => SetProblemStats(2, "Add Two Numbers", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1
        ListNode l1 = ArrayToListNode(new[] {2, 4, 3});
        ListNode l2 = ArrayToListNode(new[] {5, 6, 4});
        Console.WriteLine($"Example 1: {SolveAddTwoNumbers(l1, l2)?.ToString()}");
        
        //Example 2
        l1 = new ListNode(0);
        l2 = new ListNode(0);
        Console.WriteLine($"Example 2: {SolveAddTwoNumbers(l1, l2)?.ToString()}");
        
        //Example 3
        l1 = ArrayToListNode(new[] {9, 9, 9, 9, 9, 9, 9});
        l2 = ArrayToListNode(new[] {9, 9, 9, 9});
        Console.WriteLine($"Example 3: {SolveAddTwoNumbers(l1, l2)?.ToString()}");

        ListNode ArrayToListNode(int[] arr)
        {
            ListNode listNode = new ListNode(0, null);
            ListNode rootNode = listNode;
            for (int i = 0; i < arr.Length; i++)
            {
                listNode.Value = arr[i];
                listNode.Next = new ListNode(0, null);
                listNode = listNode.Next;
            }

            return rootNode;
        }
    }

    private ListNode SolveAddTwoNumbers(ListNode l1, ListNode l2)
    {
        string ListNodeValuesToString(ListNode listNode)
        {
            string result = "";
            while (listNode.Next != null)
            {
                result += listNode.Value.ToString();
                listNode = listNode.Next;
            }

            return result + listNode.Value.ToString();
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
            listNode.Value = int.Parse(result[i].ToString());
            listNode.Next = new ListNode(0, null);
            listNode = listNode.Next;
            
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