package binaryTree;

import java.util.Arrays;
import java.util.function.Consumer;

public class BinaryTree<E> {

	private E value;
	private BinaryTree<E> leftChild;
	private BinaryTree<E> rightChild;


	public BinaryTree(E value) {
		this.value = value;
		this.leftChild = null;
		this.rightChild = null;
	}
	
	public BinaryTree(E value, BinaryTree<E> leftChild, BinaryTree<E> rightChild) {
		this.value = value;
		this.leftChild = leftChild;
		this.rightChild = rightChild;
	}

	public void printPreOrder() {
		this.printPreOrder(0);
	}

	public void printPreOrder(int indent) {

		System.out.println(formatOutput(indent));

		if (this.leftChild != null) {
			leftChild.printPreOrder(indent + 1);
		}

		if (this.rightChild != null) {
			rightChild.printPreOrder(indent + 1);
		}
	}

	public void eachInOrder(Consumer<E> action) {

		if (this.leftChild != null) {
			this.leftChild.eachInOrder(action);
		}

		action.accept(this.value);

		if (this.rightChild != null) {
			this.rightChild.eachInOrder(action);
		}
	}

	public void eachPostOrder(Consumer<E> action) {

		if (this.leftChild != null) {
			this.leftChild.eachPostOrder(action);
		}

		if (this.rightChild != null) {
			this.rightChild.eachPostOrder(action);
		}

		action.accept(this.value);
	}

	private String formatOutput(int indent) {
		char[] indetSpaces = new char[indent * 2];
		Arrays.fill(indetSpaces, ' ');
		return String.format("%s%s", new String(indetSpaces), this.value);
	}

}
