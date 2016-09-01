package market.dataanalysistool.jpa;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;


/**
<<<<<<< Updated upstream
 * The persistent class for the market database table.
 * 
 */
@Entity
=======
 * The persistent class for the final_data database table.
 * 
 */
@Entity
@Table(name="final_data")
>>>>>>> Stashed changes
@NamedQuery(name="Market.findAll", query="SELECT m FROM Market m")
public class Market implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private MarketPK id;

<<<<<<< Updated upstream
	private BigDecimal close;

	private BigDecimal high;

	private BigDecimal low;

	private BigDecimal open;
=======
	private BigDecimal close_;

	private BigDecimal high_;

	private BigDecimal low_;

	private BigDecimal open_;
>>>>>>> Stashed changes

	private int volume;

	public Market() {
	}

	public MarketPK getId() {
		return this.id;
	}

	public void setId(MarketPK id) {
		this.id = id;
	}

<<<<<<< Updated upstream
	public BigDecimal getClose() {
		return this.close;
	}

	public void setClose(BigDecimal close) {
		this.close = close;
	}

	public BigDecimal getHigh() {
		return this.high;
	}

	public void setHigh(BigDecimal high) {
		this.high = high;
	}

	public BigDecimal getLow() {
		return this.low;
	}

	public void setLow(BigDecimal low) {
		this.low = low;
	}

	public BigDecimal getOpen() {
		return this.open;
	}

	public void setOpen(BigDecimal open) {
		this.open = open;
=======
	public BigDecimal getClose_() {
		return this.close_;
	}

	public void setClose_(BigDecimal close_) {
		this.close_ = close_;
	}

	public BigDecimal getHigh_() {
		return this.high_;
	}

	public void setHigh_(BigDecimal high_) {
		this.high_ = high_;
	}

	public BigDecimal getLow_() {
		return this.low_;
	}

	public void setLow_(BigDecimal low_) {
		this.low_ = low_;
	}

	public BigDecimal getOpen_() {
		return this.open_;
	}

	public void setOpen_(BigDecimal open_) {
		this.open_ = open_;
>>>>>>> Stashed changes
	}

	public int getVolume() {
		return this.volume;
	}

	public void setVolume(int volume) {
		this.volume = volume;
	}

}