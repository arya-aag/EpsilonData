package market.dataanalysistool.jpa;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class TickerCloseValues implements Serializable{
	List<Object[]> stockCloseValueList= new ArrayList<Object[]>();
	String startDate;
	String endDate;
	public List<Object[]> getStockCloseValueList() {
		return stockCloseValueList;
	}
	public void setStockCloseValueList(List<Object[]> stockCloseValueList) {
		this.stockCloseValueList = stockCloseValueList;
	}
	public String getStartDate() {
		return startDate;
	}
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}
	public String getEndDate() {
		return endDate;
	}
	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}
	public String getTicker() {
		return ticker;
	}
	public void setTicker(String ticker) {
		this.ticker = ticker;
	}
	String ticker;
}
