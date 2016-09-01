package market.dataanalysistool.ejb;

import java.util.List;

import javax.ejb.Local;
import javax.ejb.Remote;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;

import market.dataanalysistool.jpa.Sample;

/**
 * Session Bean implementation class SampleSessionBean
 */
@Stateless
@Remote(StockDataRemote.class)
@Local(StockDataLocal.class)
public class SampleSessionBean implements StockDataRemote, StockDataLocal {

    /**
     * Default constructor. 
     */
	@PersistenceContext(name="MarketDataAnalysisToolJPA")
	EntityManager em;
	
    public SampleSessionBean() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public List<Sample> getSample() {
		// TODO Auto-generated method stub
		String sql = "SELECT s FROM Sample AS s";
        TypedQuery<Sample> query = em.createQuery(sql, Sample.class);

        // Execute the query, and get a collection of products back.
        List<Sample> samples = query.getResultList();
		return samples;
	}

	@Override
	public void setSample(String sample) {
		// TODO Auto-generated method stub
		Sample ob = new Sample();
		ob.setSample(sample);
		em.persist(ob);
	}
	

}