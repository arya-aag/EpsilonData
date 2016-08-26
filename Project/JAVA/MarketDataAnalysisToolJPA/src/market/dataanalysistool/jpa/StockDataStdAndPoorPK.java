package market.dataanalysistool.jpa;

import java.util.Date;
import java.io.Serializable;
import javax.persistence.Embeddable;

@Embeddable
public class StockDataStdAndPoorPK implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private Date date;
	private String ticker;

	public StockDataStdAndPoorPK (){

	}

	public StockDataStdAndPoorPK(Date date, String ticker) {
		super();
		this.date = date;
		this.ticker = ticker;
	}

	public Date getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date = date;
	}

	public String getTicker() {
		return ticker;
	}

	public void setTicker(String ticker) {
		this.ticker = ticker;
	}

	/* (non-Javadoc)
	 * @see java.lang.Object#hashCode()
	 */
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((date == null) ? 0 : date.hashCode());
		result = prime * result + ((ticker == null) ? 0 : ticker.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (!(obj instanceof StockDataStdAndPoorPK))
			return false;
		if (obj == null)
			return false;

		StockDataStdAndPoorPK pk = (StockDataStdAndPoorPK) obj;
		return pk.date == date && pk.ticker.equals(ticker);
	}

}
