package market.dataanalysistool.ejb;

import java.util.List;

import javax.ejb.Local;

import market.dataanalysistool.jpa.Market;
import market.dataanalysistool.jpa.Sample;

@Local
public interface StockDataLocal {
	public Sample getSample();
	public void setSample(String sample);
	public void getObject(Sample t);
//	public Sample getParticularSample(long serialNo);
//	public void setSample(Sample sample);
	public Sample getParticularSample(long filter);
	public List<Market> getPriceTrendByTime(String string, PeriodOfTime year);
}
