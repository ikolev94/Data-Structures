package linkedList;

import java.util.Iterator;

public class LinkedList<T> implements Iterable<T> {

	private Node<T> head;
	private Node<T> tail;
	private int count;

	public int getCount() {
		return this.count;
	}

	public void setCount(int count) {
		this.count = count;
	}

	public void add(T value) {
		Node<T> newNode = new Node<T>(value);

		if (this.head == null) {
			this.head = newNode;
			this.tail = newNode;
		} else {
			this.tail.setNextNode(newNode);
			this.tail = newNode;
		}
		this.count++;
	}

	public T remove(int index) {
		if (index < 0 || index >= this.count) {
			throw new Error("Invalid Index!");
		}
		if (this.count == 0) {
			throw new Error("List is empty!");
		}
		if (index == 0) {
			T result = this.head.getValue();
			this.head = this.head.getNextNode();
			return result;
		} else {
			Node<T> current = this.head;
			for (int i = 1; i < index; i++) {
				current = current.getNextNode();
			}
			Node<T> previous = current;
			current = current.getNextNode();
			T result = current.getValue();
			Node<T> next = current.getNextNode();
			if (next == null) {
				this.tail = previous;
			}
			previous.setNextNode(next);
			return result;
		}
	}

	@Override
	public Iterator<T> iterator() {
		return new LinkedListIterator<T>(this.head);
	}

}
