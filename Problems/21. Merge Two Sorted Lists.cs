using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class MergeTwoSortedLists : BaseProblem
{
    public MergeTwoSortedLists() => SetProblemStats(21, "Merge Two Sorted Lists", Difficulty.Easy);

    protected override void ActualExecuteTest()
    {
        //Example 1
        ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4, null)));
        ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4, null)));
        Console.WriteLine($"Example 1: {SolveMergeTwoSortedLists(list1, list2).ToString()}");
        
        //Example 2
        list1 = null;
        list2 = null;
        Console.WriteLine($"Example 2: {SolveMergeTwoSortedLists(list1, list2).ToString()}");
        
        //Example 3
        list1 = null;
        list2 = new ListNode(0, null);
        Console.WriteLine($"Example 3: {SolveMergeTwoSortedLists(list1, list2).ToString()}");
    }

    private ListNode SolveMergeTwoSortedLists(ListNode node1, ListNode node2)
    {
        if (node1 == null && node2 == null)
            return null;
        
        ListNode head = new ListNode(Math.Min(node1?.Value ?? 101, node2?.Value ?? 101), null);
        ListNode node = head;
        
        //Advance starter node
        if (node.Value == node1?.Value)
            node1 = node1?.Next;
        else
            node2 = node2?.Next;

        
        while (node1 != null || node2 != null)
        {
            if (node2 == null || node1?.Value <= node2.Value)
            {
                node.Next = node1;
                node1 = node1.Next;
            }
            else if (node1 == null || node1.Value > node2?.Value)
            {
                node.Next = node2;
                node2 = node2.Next;
            }
            
            node = node.Next;
        }
        
        return head;
    }
}