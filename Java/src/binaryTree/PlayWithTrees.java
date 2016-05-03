package binaryTree;

public class PlayWithTrees {

	public static void main(String[] args) {
		
		Tree<Integer> tree = 
				new Tree<Integer>(5,
						new Tree<>(13,
								new Tree<>(2),
								new Tree<>(44),
								new Tree<>(12)),
						new Tree<>(43,
								new Tree<>(47),
								new Tree<>(42)),
						new Tree<>(11));
		
		System.out.println("Test print (tree)");
		tree.print();
		System.out.println("Test each (tree)");
		tree.each(n->System.out.print(" " + n));
		
		
		
		BinaryTree<String> binaryTree = 
				new BinaryTree<String>("*",
						new BinaryTree<>("+",
								new BinaryTree<>("12"),
								new BinaryTree<>("1")),
						new BinaryTree<>("-",
								new BinaryTree<>("9"),			
								new BinaryTree<>("3")));
		
		System.out.println("\n\nBinary tree (indented pre-order)");
		binaryTree.printPreOrder();
		

		System.out.println("\n\nBinary tree (in-order)");
		binaryTree.eachInOrder(n->System.out.print(" " + n));
		

		System.out.println("\n\nBinary tree (post-order)");
		binaryTree.eachPostOrder(n -> System.out.print(" " + n));	
		
	}

}
