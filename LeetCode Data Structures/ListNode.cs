namespace LeetCode.DataStructures;

public class ListNode
{
    public int Value;
    public ListNode Next;
    
    public ListNode(int value = 0, ListNode next = null) 
    {
        this.Value = value;
        this.Next = next;
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

    public override string ToString() => String.Join(", ", OutputListNode(this));
}