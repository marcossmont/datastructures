namespace BinaryTree.NodeDeletion
{
    internal class RighChildtWitLeftChildNodeDeletionStrategy : INodeDeletionStrategy
    {
        private MyBinaryTreeNode node;

        public RighChildtWitLeftChildNodeDeletionStrategy(MyBinaryTreeNode node)
        {
            this.node = node;
        }

        public MyBinaryTreeNode Delete()
        {
            var leftmostParent = node.Right;
            var leftmostNode = node.Right.Left;

            while (leftmostNode.Left != null)
            {
                leftmostParent = leftmostNode;
                leftmostNode = leftmostNode.Left;
            }

            leftmostParent.Left = leftmostNode.Right;

            leftmostNode.Left = node.Left;
            leftmostNode.Right = node.Right;

            return leftmostNode;
        }
    }
}