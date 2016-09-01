package market.dataanalysistool.ejb;

<<<<<<< Updated upstream
import java.util.Date;
import java.util.Map;

import javax.ejb.Remote;

import market.dataanalysistool.jpa.MarketPK;

@Remote
public interface StockStdAndPoorSessionBeanRemote {
	public Map<Date,Double> getSimpleMovingAverages(MarketPK stock, int timePeriod);
	public Map<Date,Double> getExponentialMovingAverages(MarketPK stock, int timePeriod);
	public Map<Date,Double> getPriceTrendByTime(MarketPK stock, PeriodOfTime timePeriod);
	public Map<Date,Double> getVolumeTrendByTime(MarketPK stock, PeriodOfTime timePeriod);
=======
import java.util.List;

import javax.ejb.Remote;

import market.dataanalysistool.jpa.Market;
import market.dataanalysistool.jpa.TickerCloseValues;

@Remote
public interface StockStdAndPoorSessionBeanRemote {
//	public List<Point> getSimpleMovingAverages(String ticker, int timePeriod, PeriodOfTime t);
	//public List<Point> getExponentialMovingAverages(String ticker, int timePeriod, PeriodOfTime t);
	public TickerCloseValues getPriceTrendByTime(String ticker, PeriodOfTime timePeriod);
	public List<Market> getVolumeTrendByTime(String ticker, PeriodOfTime timePeriod);
	public List<Market> getAllStocks();
	public List<Object[]> getAllTickers();
>>>>>>> Stashed changes
}
