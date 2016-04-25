package doublyLinkedList;

public class DoublyLinkedListTest {

	public static void main(String[] args) {
		
		DoublyLinkedList<String> numbs = new DoublyLinkedList<>(); 
		numbs.addFirs("Three");
		numbs.addFirs("Two");
		numbs.addFirs("One");
		numbs.addFirs("Zero");
		
		
		numbs.addLast("Four");
		System.out.println("remove -> "+numbs.removeFirst());
		System.out.println("remove -> "+numbs.removeLast());

		System.out.println(String.join(", ", numbs));

	}

}
