package market.dataanalysistool.ejb;

import java.util.List;

import javax.ejb.Remote;

import market.dataanalysistool.jpa.Sample;

@Remote
public interface StockDataRemote {
	public List<Sample> getSample();
	public void setSample(String sample);
}