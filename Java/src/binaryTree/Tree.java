package binaryTree;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.function.Consumer;

public class Tree<E> {

	private E value;
	private ArrayList<Tree<E>> children;

	@SafeVarargs
	public Tree(E value, Tree<E>... children) {
		this.value = value;
		this.children = new ArrayList<>();

		for (Tree<E> node : children) {
			this.children.add(node);
		}
	}

	public void print() {
		this.print(0);
	}

	public void print(int indent) {
		char[] indetSpaces = new char[indent * 2];
		Arrays.fill(indetSpaces, ' ');
		String result = String.format("%s%s", new String(indetSpaces), this.value);
		System.out.println(result);
		
		for (Tree<E> c : this.children) {
			c.print(indent + 1);
		}
	}
	
	public void each(Consumer<E> action) {
		action.accept(value);
		
		for (Tree<E> tree : this.children) {
			tree.each(action);
		}
	}

}
