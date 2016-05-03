package binaryHeap;

public class Example {
	public static void main(String[] args) {
		
		BinaryHeap<Integer> heap = new BinaryHeap<>();
		heap.insert(2);
		heap.insert(332);
		heap.insert(4);
		heap.insert(-11);
		heap.insert(23);
		
		System.out.println("Heap elements (max to min)");
		while (heap.size() > 0) {
			System.out.println(heap.extractMax());
		}
		
	}
}
