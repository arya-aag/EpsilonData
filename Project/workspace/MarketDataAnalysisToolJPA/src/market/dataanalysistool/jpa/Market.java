package market.dataanalysistool.jpa;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;


/**
 * The persistent class for the market database table.
 * 
 */
@Entity
@NamedQuery(name="Market.findAll", query="SELECT m FROM Market m")
public class Market implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private MarketPK id;

	private BigDecimal close;

	private BigDecimal high;

	private BigDecimal low;

	private BigDecimal open;

	private int volume;

	public Market() {
	}

	public MarketPK getId() {
		return this.id;
	}

	public void setId(MarketPK id) {
		this.id = id;
	}

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
	}

	public int getVolume() {
		return this.volume;
	}

	public void setVolume(int volume) {
		this.volume = volume;
	}

}