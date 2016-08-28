package market.dataanalysistool.ejb;

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
}
