namespace BinaryTree.NodeDeletion
{
    public class WithoutRightChildNodeDeletionStrategy : INodeDeletionStrategy
    {
        private MyBinaryTreeNode node;

        public WithoutRightChildNodeDeletionStrategy(MyBinaryTreeNode node)
        {
            this.node = node;
        }

        public MyBinaryTreeNode Delete()
        {
            return node.Left;
        }
    }
}