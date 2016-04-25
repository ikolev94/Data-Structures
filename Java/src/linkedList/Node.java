package linkedList;

public class Node<T> {

	private T value;
	private Node<T> nextNode;

	public Node(T value) {
		this.setValue(value);
	}

	public T getValue() {
		return this.value;
	}

	private void setValue(T value) {
		this.value = value;
	}

	public Node<T> getNextNode() {
		return nextNode;
	}

	public void setNextNode(Node<T> nextNode) {
		this.nextNode = nextNode;
	}

}
