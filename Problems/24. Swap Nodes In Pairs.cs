using LeetCode.DataStructures;

namespace LeetCode;

public class SwapNodesInPairs : BaseProblem
{
    public SwapNodesInPairs() => SetProblemStats(24, "Swap Nodes In Pairs", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, null))));
        Console.WriteLine($"Example 1: [{SolveSwapNodesInPairs(head)?.ToString()}]");
        
        //Example 2
        head = null;
        Console.WriteLine($"Example 2: [{SolveSwapNodesInPairs(head)?.ToString()}]");
        
        //Example 3
        head = new ListNode(1, null);
        Console.WriteLine($"Example 3: [{SolveSwapNodesInPairs(head)?.ToString()}]");
    }

    private ListNode SolveSwapNodesInPairs(ListNode head)
    {
        if (head == null || head.Next == null)
            return head;
        
        ListNode dummyHead = new ListNode(0, null);

        ListNode previous = dummyHead;
        ListNode current = head;

        while (current != null && current.Next != null)
        {
            previous.Next = current.Next;
            current.Next = previous.Next.Next;
            previous.Next.Next = current;

            previous = current;
            current = current.Next;
        }
        
        return dummyHead.Next;
    }
}