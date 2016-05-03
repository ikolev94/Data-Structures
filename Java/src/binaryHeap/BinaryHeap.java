package binaryHeap;

import java.util.ArrayList;
import java.util.List;

public class BinaryHeap<E extends Comparable<E>> {

	private List<E> heap;

	public BinaryHeap() {
		this.heap = new ArrayList<>();
	}

	public int size() {
		return this.heap.size();
	}

	public E extractMax() {
		E max = this.heap.get(0);

		this.heap.set(0, this.heap.get(this.size() - 1));
		this.heap.remove(this.size() - 1);
		if (this.size() > 0) {
			this.heapifyDown(0);
		}

		return max;
	}

	public E peakMax() {
		return this.heap.get(0);
	}

	public void insert(E value) {
		this.heap.add(value);
		this.heapifyUp(this.size() - 1);
	}

	private void heapifyUp(int i) {
		int parent = (i - 1) / 2;
		while (i > 0 && this.heap.get(i).compareTo(this.heap.get(parent)) > 0) {
			E old = this.heap.get(i);
			this.heap.set(i, this.heap.get(parent));
			this.heap.set(parent, old);
			i = parent;
			parent = (i - 1) / 2;
		}
	}

	private void heapifyDown(int i) {
		int left = (2 * i) + 1;
		int right = (2 * i) + 2;
		int largest = i;
		if (left < this.size() && this.heap.get(left).compareTo(this.heap.get(largest)) > 0) {
			largest = left;
		}

		if (right < this.size() && this.heap.get(right).compareTo(this.heap.get(largest)) > 0) {
			largest = right;
		}

		if (largest != i) {
			E old = this.heap.get(i);
			this.heap.set(i, this.heap.get(largest));
			this.heap.set(largest, old);
			heapifyDown(largest);
		}
	}

}
