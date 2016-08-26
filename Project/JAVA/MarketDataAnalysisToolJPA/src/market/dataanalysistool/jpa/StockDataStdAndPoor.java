package market.dataanalysistool.jpa;

import java.io.Serializable;

import javax.persistence.*;


@Entity
@Table(name="StockDataSAndP")
public class StockDataStdAndPoor implements Serializable {

	
	private static final long serialVersionUID = 1L;

	private StockDataStdAndPoorPK pk;
	private double open;
	private double high;
	private double low;
	private double close;
	private long volume;
	
	
	/**
	 * @return the pk
	 */
	@EmbeddedId
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	public StockDataStdAndPoorPK getPk() {
		return pk;
	}
	/**
	 * @param pk the pk to set
	 */
//	public void setPk(StockDataStdAndPoorPK pk) {
//		this.pk = pk;
//	}
	/**
	 * @return the open
	 */
	public double getOpen() {
		return open;
	}
	/**
	 * @param open the open to set
	 */
	public void setOpen(double open) {
		this.open = open;
	}
	/**
	 * @return the high
	 */
	public double getHigh() {
		return high;
	}
	/**
	 * @param high the high to set
	 */
	public void setHigh(double high) {
		this.high = high;
	}
	/**
	 * @return the low
	 */
	public double getLow() {
		return low;
	}
	/**
	 * @param low the low to set
	 */
	public void setLow(double low) {
		this.low = low;
	}
	/**
	 * @return the close
	 */
	public double getClose() {
		return close;
	}
	/**
	 * @param close the close to set
	 */
	public void setClose(double close) {
		this.close = close;
	}
	/**
	 * @return the volume
	 */
	public long getVolume() {
		return volume;
	}
	/**
	 * @param volume the volume to set
	 */
	public void setVolume(long volume) {
		this.volume = volume;
	}
		
	
	public StockDataStdAndPoor() {
		super();
	}

	
}
