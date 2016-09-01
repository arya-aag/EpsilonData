package market.dataanalysistool.jpa;

import java.io.Serializable;
import javax.persistence.*;

/**
<<<<<<< Updated upstream
 * The primary key class for the market database table.
=======
 * The primary key class for the final_data database table.
>>>>>>> Stashed changes
 * 
 */
@Embeddable
public class MarketPK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

<<<<<<< Updated upstream
	private String date;

	private String ticker;

	public MarketPK() {
	}
	public String getDate() {
		return this.date;
	}
	public void setDate(String date) {
		this.date = date;
	}
	public String getTicker() {
		return this.ticker;
	}
	public void setTicker(String ticker) {
		this.ticker = ticker;
	}
	
	@Override
=======
	private String ticker_;

	@Temporal(TemporalType.DATE)
	private java.util.Date x_Date;

	public MarketPK() {
	}
	public String getTicker_() {
		return this.ticker_;
	}
	public void setTicker_(String ticker_) {
		this.ticker_ = ticker_;
	}
	public java.util.Date getX_Date() {
		return this.x_Date;
	}
	public void setX_Date(java.util.Date x_Date) {
		this.x_Date = x_Date;
	}

>>>>>>> Stashed changes
	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof MarketPK)) {
			return false;
		}
		MarketPK castOther = (MarketPK)other;
		return 
<<<<<<< Updated upstream
			this.date.equals(castOther.date)
			&& this.ticker.equals(castOther.ticker);
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.date.hashCode();
		hash = hash * prime + this.ticker.hashCode();
=======
			this.ticker_.equals(castOther.ticker_)
			&& this.x_Date.equals(castOther.x_Date);
	}

	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.ticker_.hashCode();
		hash = hash * prime + this.x_Date.hashCode();
>>>>>>> Stashed changes
		
		return hash;
	}
}