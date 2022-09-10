using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class MergeKSortedLists : BaseProblem
{
    public MergeKSortedLists() => SetProblemStats(23, "Merge k Sorted Lists", Difficulty.Hard);

    protected override void ActualExecuteTest()
    {
        //Example 1
        ListNode[] lists = new ListNode[] 
        {
            new ListNode(1, new ListNode(4, new ListNode(5, null))),
            new ListNode(1, new ListNode(3, new ListNode(4, null))),
            new ListNode(2, new ListNode(6, null))
        };
        Console.WriteLine($"Example 1: {SolveMergeKSortedLists(lists).ToString()}");
        
        //Example 2
        lists = new ListNode[0];
        Console.WriteLine($"Example 2: {SolveMergeKSortedLists(lists).ToString()}");
        
        //Example 3
        lists = new ListNode[1];
        Console.WriteLine($"Example 3: {SolveMergeKSortedLists(lists).ToString()}");
    }

    private ListNode SolveMergeKSortedLists(ListNode[] lists)
    {
        PriorityQueue<ListNode, int> pQueue = new PriorityQueue<ListNode, int>(lists.Length);

        foreach (ListNode listNode in lists)
            if (listNode != null)
                pQueue.Enqueue(listNode, listNode.Value);

        ListNode head = new ListNode(0, null);
        ListNode node = head; //Our linked list tail
        while (pQueue.Count > 0)
        {
            node.Next = pQueue.Dequeue();
            node = node.Next;

            if (node.Next != null)
                pQueue.Enqueue(node.Next, node.Next.Value);
        }

        return head.Next; //Because the head's starting value is a dummy value -> simplifies code
    }
}