
package doublyLinkedList;

public class Node<E> {

	private E value;
	private Node<E> nextNode;
	private Node<E> previousNode;
	
	public Node(E value) {
		this.setValue(value);
	}

	public E getValue() {
		return this.value;
	}

	private void setValue(E value) {
		this.value = value;
	}

	public Node<E> getNextNode() {
		return this.nextNode;
	}

	public void setNextNode(Node<E> nextNode) {
		this.nextNode = nextNode;
	}

	public Node<E> getPreviousNode() {
		return this.previousNode;
	}

	public void setPreviousNode(Node<E> previousNode) {
		this.previousNode = previousNode;
	}
}