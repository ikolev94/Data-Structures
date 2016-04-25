package linkedListDemo;

public class LinkedListTest {

	public static void main(String[] args) {

		LinkedList<Integer> myList = new LinkedList<>();

		myList.add(1);
		myList.add(2);
		myList.add(3);
		myList.add(4);
		myList.remove(0);

		for (Integer integer : myList) {
			System.out.println(integer);
		}

	}

}
