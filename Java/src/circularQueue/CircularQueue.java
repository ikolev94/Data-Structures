package circularQueue;

public class CircularQueue<E> {

	private final int DEFAULT_CAPACITY = 16;
	private int start;
	private int end;
	private E[] elements;
	private int count;

	@SuppressWarnings("unchecked")
	public CircularQueue(int capacity) {
		this.elements = (E[]) new Object[capacity];
	}

	@SuppressWarnings("unchecked")
	public CircularQueue() {
		this.elements = (E[]) new Object[DEFAULT_CAPACITY];
	}

	public int getCount() {
		return this.count;
	}

	public void enqueue(E element) {
		if (this.count >= this.elements.length) {
			this.grow();
		}

		this.elements[this.end] = element;
		this.end = (this.end + 1) % this.elements.length;
		this.count++;
	}

	public E dequeue() {
		if (this.count == 0) {
			throw new Error("Queue is empty");
		}
		E result = this.elements[this.start];
		this.start = (this.start + 1) % this.elements.length;
		this.count--;

		return result;
	}

	private void grow() {
		@SuppressWarnings("unchecked")
		E[] newElements = (E[]) new Object[2 * this.elements.length];

		this.copyElements(newElements);
		this.elements = newElements;
		this.start = 0;
		this.end = this.count;
	}

	private void copyElements(E[] newElements) {
		int index = this.start;
		for (int i = 0; i < this.count; i++) {
			newElements[i] = this.elements[index];
			index = (index + 1) % this.elements.length;
		}
	}

}
