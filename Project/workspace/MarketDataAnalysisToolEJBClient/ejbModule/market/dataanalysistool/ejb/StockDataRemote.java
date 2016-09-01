package market.dataanalysistool.ejb;

import java.util.List;

import javax.ejb.Remote;

import market.dataanalysistool.jpa.Sample;

@Remote
public interface StockDataRemote {
	public Sample getSample();
	public void setSample(String sample);
	public void getObject(Sample t);
//	public Sample getParticularSample(long serialNo);
//	public void setSample(Sample sample);
}
