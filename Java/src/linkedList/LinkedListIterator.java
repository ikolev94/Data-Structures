package linkedList;

import java.util.Iterator;

public class LinkedListIterator<T> implements Iterator<T> {

	private Node<T> currentNode;

	public LinkedListIterator(Node<T> head) {
		this.currentNode = head;
	}

	@Override
	public boolean hasNext() {
		return this.currentNode != null;
	}

	@Override
	public T next() {
		T result = currentNode.getValue();
		currentNode = currentNode.getNextNode();
		return result;
	}

}
