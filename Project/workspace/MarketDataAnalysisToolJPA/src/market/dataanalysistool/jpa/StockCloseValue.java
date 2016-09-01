package market.dataanalysistool.jpa;

public class StockCloseValue {
	int relativeDateDifference;
	double closeValue;
	public int getRelativeDateDifference() {
		return relativeDateDifference;
	}
	public void setRelativeDateDifference(int relativeDateDifference) {
		this.relativeDateDifference = relativeDateDifference;
	}
	public double getCloseValue() {
		return closeValue;
	}
	public void setCloseValue(double closeValue) {
		this.closeValue = closeValue;
	}

}
