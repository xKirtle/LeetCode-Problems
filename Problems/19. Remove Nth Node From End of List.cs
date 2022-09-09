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
    private class ListNode
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
        ListNode[] nodes = new ListNode[n + 1];

        ListNode currentNode = head;
        while (currentNode != null)
        {
            nodes[count++ % nodes.Length] = currentNode;
            currentNode = currentNode.Next;
        }

        if (count == n)
            return head.Next;

        //Get the node before the target n and "remove" the target n
        currentNode = nodes[(count - n - 1) % nodes.Length];
        currentNode.Next = currentNode.Next.Next;
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