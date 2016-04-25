package linkedList;

public class LinkedListTest {

	public static void main(String[] args) {

		LinkedList<Integer> numbers = new LinkedList<>();

		numbers.add(1);
		numbers.add(2);
		numbers.add(3);
		numbers.add(4);
		numbers.remove(0);

		for (Integer number : numbers) {
			System.out.println(number);
		}

		LinkedList<String> words = new LinkedList<>();

		words.add("This");
		words.add("Is");
		words.add("Is");
		words.add("Test");
		words.remove(2);

		for (String word : words) {
			System.out.println(word);
		}

	}

}
