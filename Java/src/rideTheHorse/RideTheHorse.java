package rideTheHorse;

import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

public class RideTheHorse {

	/*
    You are given a matrix N x M and a start position.Your task is to traverse the matrix
    using the movements of the horse from the chess game and marking where you have gone.
    1.	Visit the start position and assign 1 in it.
    2.	If a position holds the value V, assign V+1 in all not-visited cells which can
    be reached by movement of the horse from this position.
    3.	Repeat the previous step until all positions are visited.
    */
	
	static int[][] board;

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		System.out.print("Board rows = ");
		int boardRows = scanner.nextInt();

		System.out.print("Board cols = ");
		int boardCols = scanner.nextInt();

		System.out.println("Start position of the horse");
		System.out.printf("Row range [0..%d]%n",boardRows-1);
		System.out.print("Row = ");
		int startRow = scanner.nextInt();
		
		System.out.printf("Col range [0..%d]%n",boardCols-1);
		System.out.print("Col = ");
		int startCol = scanner.nextInt();
		scanner.close();

		board = new int[boardRows][boardCols];

		board[startRow][startCol] = 1;

		Queue<Cell> horseMoves = new LinkedList<>();
		horseMoves.add(new Cell(startRow, startCol));

		while (!horseMoves.isEmpty()) {

			Cell current = horseMoves.poll();

			addMove(horseMoves, current, -1, -2);
			addMove(horseMoves, current, -1, 2);
			addMove(horseMoves, current, 1, -2);
			addMove(horseMoves, current, 1, 2);

			addMove(horseMoves, current, -2, -1);
			addMove(horseMoves, current, -2, 1);
			addMove(horseMoves, current, 2, -1);
			addMove(horseMoves, current, 2, 1);

		}
		
		printBoard();

	}

	private static void printBoard() {

		for (int[] row : board) {
			System.out.print("|");
			for (int num : row) {
				System.out.printf(" %d |",num);
			}
			System.out.println();
		}
	}

	private static void addMove(Queue<Cell> horseMoves, Cell current, int rowUpdate, int colUpdate) {

		int newRow = current.getRow() + rowUpdate;
		int newCol = current.getCol() + colUpdate;

		if (isValidCell(current, newRow, newCol)) {
			horseMoves.add(new Cell(newRow, newCol));
			board[newRow][newCol] = board[current.getRow()][current.getCol()] + 1;
		}
	}

	private static boolean isValidCell(Cell current, int newRow, int newCol) {

		if (newRow < 0 || newRow >= board.length) {
			return false;
		}

		if (newCol < 0 || newCol >= board[0].length) {
			return false;
		}

		if (board[newRow][newCol] != 0) {
			return false;
		}

		return true;
	}

}
