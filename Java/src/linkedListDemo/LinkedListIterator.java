package linkedListDemo;

import java.util.Iterator;

public class LinkedListIterator<T> implements Iterator<T> {

	private LinkedList<T> list;
	private Node<T> currentNode;

	public LinkedListIterator(LinkedList<T> list) {
		this.list = list;
		this.currentNode = list.getHead();
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
