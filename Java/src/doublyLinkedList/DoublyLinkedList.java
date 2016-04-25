package doublyLinkedList;

import java.util.Iterator;

public class DoublyLinkedList<E> implements Iterable<E> {

	private final String EMPTY_LIST_ERROR_MESSAGE = "List is empty";
	private Node<E> head;
	private Node<E> tail;
	private int count;

	public int getCount() {
		return this.count;
	}

	public void addFirs(E element) {

		Node<E> newElement = new Node<E>(element);

		if (this.head == null) {
			this.head = newElement;
			this.tail = newElement;
		} else {
			newElement.setNextNode(this.head);
			this.head.setPreviousNode(newElement);
			this.head = newElement;
		}
		this.count++;
	}

	public void addLast(E element) {
		Node<E> newElement = new Node<E>(element);

		if (this.tail == null) {
			this.head = newElement;
			this.tail = newElement;
		} else {
			newElement.setPreviousNode(this.tail);
			this.tail.setNextNode(newElement);
			this.tail = newElement;
		}
		this.count++;
	}

	public E removeFirst() {
		if (this.head == null) {
			throw new Error(EMPTY_LIST_ERROR_MESSAGE);
		}
		E result = this.head.getValue();
		this.head = this.head.getNextNode();

		if (this.head == null) {
			this.tail = null;
		} else {
			this.head.setPreviousNode(null);
		}
		this.count--;
		return result;
	}

	public E removeLast() {
		if (this.tail == null) {
			throw new Error(EMPTY_LIST_ERROR_MESSAGE);
		}
		E result = this.tail.getValue();

		this.tail = this.tail.getPreviousNode();

		if (this.tail == null) {
			this.head = null;
		} else {
			this.tail.setNextNode(null);
		}
		this.count--;
		return result;
	}

	@Override
	public Iterator<E> iterator() {
		return new DoublyLinkedListIterator<E>(this.head); 
	}
}

