package circularQueue;

public class CircularQueueExample {

	public static void main(String[] args) {

		CircularQueue<String> circularQueueText = new CircularQueue<>();

		circularQueueText.enqueue("Hello");
		circularQueueText.enqueue("I am");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
		circularQueueText.enqueue("Example");
	

		System.out.printf("Count = %d%n", circularQueueText.getCount());
		
		System.out.println(circularQueueText.dequeue());
		System.out.printf("Count = %d%n", circularQueueText.getCount());

		
		CircularQueue<Integer> circularQueueNumbers = new CircularQueue<>();
		
		circularQueueNumbers.enqueue(1);
		circularQueueNumbers.enqueue(2);
		circularQueueNumbers.enqueue(3);
		circularQueueNumbers.enqueue(4);
		
		System.out.println(circularQueueNumbers.dequeue());
		System.out.println(circularQueueNumbers.dequeue());
	}

}
