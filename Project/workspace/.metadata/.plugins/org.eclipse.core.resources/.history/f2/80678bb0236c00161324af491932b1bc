import java.util.List;
import java.util.Properties;

import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;

import market.dataanalysistool.ejb.StockDataRemote;
import market.dataanalysistool.jpa.Sample;

public class Main {
	public static void main(String[] args) throws NamingException {
		// TODO Auto-generated method stub

		// Create Properties for JNDI InitialContext.
		Properties prop = new Properties();
		prop.put(Context.INITIAL_CONTEXT_FACTORY, org.jboss.naming.remote.client.InitialContextFactory.class.getName()); 
		prop.put(Context.URL_PKG_PREFIXES, "org.jboss.ejb.client.naming");
		prop.put(Context.PROVIDER_URL, "http-remoting://localhost:8080");
		prop.put("jboss.naming.client.ejb.context", true);

		// Create the JNDI InitialContext.
		Context context = new InitialContext(prop);

		// Formulate the full JNDI name for the Diary session bean.
		String appName     = "MarketDataAnalysisTool";
		String moduleName  = "MarketDataAnalysisToolEJB";
		String beanName    = "StockDataSessionBean";
		String packageName = "market.dataanalysistool.ejb";
		String className   = "StockDataRemote";

		// Lookup the bean using the full JNDI name.
		String fullJndiName = String.format("%s/%s/%s!%s.%s", appName, moduleName, beanName, packageName, className);
		StockDataRemote bean = (StockDataRemote) context.lookup(fullJndiName);
		List<Sample> ob = bean.getSample();
		System.out.println(ob);
	}

	/* (non-Java-doc)
	 * @see java.lang.Object#Object()
	 */
	public Main() {
		super();
	}

}