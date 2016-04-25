package doublyLinkedList;

import java.util.Iterator;

public class DoublyLinkedListIterator<E> implements Iterator<E>{

	private Node<E> currentNode;

	public DoublyLinkedListIterator(Node<E> head) {
		this.currentNode = head;
	}
	
	
	@Override
	public boolean hasNext() {
		return this.currentNode != null;
	}

	@Override
	public E next() {
		E result = currentNode.getValue();
		currentNode = currentNode.getNextNode();
		return result;

	}

}
