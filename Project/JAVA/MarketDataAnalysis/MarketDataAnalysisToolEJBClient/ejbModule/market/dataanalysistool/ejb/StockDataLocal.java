package market.dataanalysistool.ejb;

import java.util.List;

import javax.ejb.Local;

import market.dataanalysistool.jpa.Sample;

@Local
public interface StockDataLocal {
	public List<Sample> getSample();
	public void setSample(String sample);
}
