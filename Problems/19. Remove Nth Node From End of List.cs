using System.Collections.ObjectModel;

namespace LeetCode.Problems;

public class RemoveNthNodeFromEndList : BaseProblem
{
    public RemoveNthNodeFromEndList() => SetProblemStats(19, "Remove Nth Node From End of List", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))));
        int index = 2;
        ListNode node = SolveRemoveNthNodeFromEndList(head, index);
        Console.WriteLine($"Example 1: [{String.Join(", ", OutputListNode(node))}]");
        
        //Example 2
        head = new ListNode(1, null);
        index = 1;
        node = SolveRemoveNthNodeFromEndList(head, index);
        Console.WriteLine($"Example 2: [{String.Join(", ", OutputListNode(node))}]");
        
        //Example 3
        head = new ListNode(1, new ListNode(2, null));
        index = 1;
        node = SolveRemoveNthNodeFromEndList(head, index);
        Console.WriteLine($"Example 3: [{String.Join(", ", OutputListNode(node))}]");
        
        //Example 4
        head = new ListNode(1, new ListNode(2, null));
        index = 2;
        node = SolveRemoveNthNodeFromEndList(head, index);
        Console.WriteLine($"Example 4: [{String.Join(", ", OutputListNode(node))}]");
    }
    
    //LeetCode's implementation
    public class ListNode
    {
      public int Value;
      public ListNode Next;
      public ListNode(int value = 0, ListNode next = null) 
      {
          this.Value = value;
          this.Next = next;
      }
    }

    private ListNode SolveRemoveNthNodeFromEndList(ListNode head, int n)
    {
        int count = 0;
        LinkedList<ListNode> nodes = new LinkedList<ListNode>();
    
        ListNode current = head;
        while (current != null)
        {
            count++;
            nodes.AddLast(current);
            current = current.Next;
            
            if (nodes.Count > n + 1)
                nodes.RemoveFirst();
        }
    
        if (nodes.Count == 1)
            return null;
        else if (count == n) //Remove first element
            head = nodes.First.Next.Value;
        else if (n == 1) //Remove last element
            nodes.Last.Previous.Value.Next = null;
        else
            nodes.First.Value.Next = nodes.First.Next.Next.Value;
    
        return head;
    }

    private IEnumerable<string> OutputListNode(ListNode node)
    {
        if (node != null)
        {
            do
            {
                string value = node.Value.ToString();
                node = node.Next;
                yield return value;
            } while (node?.Next != null);

            if (node != null)
                yield return node.Value.ToString();
        }
    }
}