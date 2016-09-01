package market.dataanalysistool.ejb;

<<<<<<< Updated upstream
import java.util.Date;
import java.util.Map;
import javax.ejb.Local;
import market.dataanalysistool.jpa.MarketPK;
=======
import java.util.List;
import javax.ejb.Local;

import market.dataanalysistool.jpa.Market;
import market.dataanalysistool.jpa.TickerCloseValues;
>>>>>>> Stashed changes
/*
 * This interface details the list of methods that can be implemented on the database of the S&P 500
 */
@Local
public interface StockStdAndPoorSessionBeanLocal {
<<<<<<< Updated upstream
	public Map<Date,Double> getSimpleMovingAverages(MarketPK stock, int timePeriod);
	public Map<Date,Double> getExponentialMovingAverages(MarketPK stock, int timePeriod);
	public Map<Date,Double> getPriceTrendByTime(MarketPK stock, PeriodOfTime timePeriod);
	public Map<Date,Double> getVolumeTrendByTime(MarketPK stock, PeriodOfTime timePeriod);
}
=======
	public List<Point> getSimpleMovingAverages(String ticker, int timePeriod, PeriodOfTime t);
    public List<Point> getExponentialMovingAverages(String ticker, int timePeriod, PeriodOfTime t);
	public TickerCloseValues getPriceTrendByTime(String ticker, PeriodOfTime timePeriod);
	public List<Market> getVolumeTrendByTime(String ticker, PeriodOfTime timePeriod);
	public List<Market> getAllStocks();
	List<Object[]> getAllTickers();
}

>>>>>>> Stashed changes
