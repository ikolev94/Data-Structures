package rideTheHorse;

public class Cell {
	
	private int row;
	private int col;
	
	public Cell(int row, int col) {
		this.setRow(row);
		this.setCol(col);
	}

	public int getRow() {
		return this.row;
	}

	public void setRow(int row) {
		this.row = row;
	}

	public int getCol() {
		return this.col;
	}

	public void setCol(int col) {
		this.col = col;
	}
}
