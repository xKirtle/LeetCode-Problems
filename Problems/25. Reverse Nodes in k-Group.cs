using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class ReverseNodesInKGroup : BaseProblem
{
    public ReverseNodesInKGroup() => SetProblemStats(25, "Reverse Nodes in k-Group", Difficulty.Hard);

    protected override void ActualExecuteTest()
    {
        //Example 1
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        Console.WriteLine($"Example 1: {(SolveReverseKGroup(head, 2)).ToString()}");
        
        //Example 2
        head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        Console.WriteLine($"Example 2: {SolveReverseKGroup(head, 3).ToString()}");

        //Example 3
        head = new ListNode(1, new ListNode(2));
        Console.WriteLine($"Example 3: {SolveReverseKGroup(head, 2).ToString()}");

        // Example 4
        head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
        Console.WriteLine($"Example 4: {SolveReverseKGroup(head, 2).ToString()}");
    }
    
    private ListNode SolveReverseKGroup(ListNode head, int k)
    {
        Queue<ListNode> queue = new Queue<ListNode>(capacity: k);
        ListNode node = head;
        ListNode previousNode = null;
        int counter = 0;
        
        while (node != null)
        {
            queue.Enqueue(node);
            node = node.Next;
            
            if (++counter % k == 0)
            {
                bool isFirstGroup = counter == k;
                ListNode tempLastNode = node;
                ListNode newPreviousNode = queue.Peek(); // This is the last element of the current group
                
                // reverse group and point new right side element of group to outside the group
                while (queue.Count > 0)
                {
                    ListNode dequeuedNode = queue.Dequeue();
                    dequeuedNode.Next = tempLastNode;
                    tempLastNode = dequeuedNode;
                    // tempLastNode ends up being the first element of the group
                }

                if (isFirstGroup)
                {
                    // Set first element of group as the head
                    head = tempLastNode; 
                }
                else
                {
                    // Connect last element before the group to first element of the group
                    previousNode.Next = tempLastNode;
                }

                previousNode = newPreviousNode;
                queue.Clear();
            }
        }

        return head;
    }
}