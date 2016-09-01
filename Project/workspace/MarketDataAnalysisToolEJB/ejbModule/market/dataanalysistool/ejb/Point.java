package market.dataanalysistool.ejb;

import java.io.Serializable;
import java.util.Date;

public class Point implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private Date date;
	private Double yCoordinate;
	
	
	
	public Date getDate() {
		return date;
	}
	public void setDate(Date date) {
		this.date = date;
	}
	public Double getyCoordinate() {
		return yCoordinate;
	}
	public void setyCoordinate(Double yCoordinate) {
		this.yCoordinate = yCoordinate;
	}
	
}
