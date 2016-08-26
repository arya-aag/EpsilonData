package market.dataanalysistool.web;

import java.util.List;

import javax.enterprise.context.RequestScoped;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.ws.rs.Consumes;
import javax.ws.rs.DefaultValue;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.Response;

import market.dataanalysistool.ejb.StockDataLocal;
import market.dataanalysistool.jpa.Sample;

@RequestScoped
@Path("/stock")
@Produces({"application/xml", "application/json"})
@Consumes({"application/xml", "application/json"})
public class StockResource {
	StockDataLocal bean;
	Context context;
	
	public StockResource() {
		try {
			context = new InitialContext();
			bean = (StockDataLocal)context.lookup("java:app/MarketDataAnalysisToolEJB/StockDataSessionBean!market.dataanalysistool.ejb.StockDataLocal");
		}
		catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	@GET
	@Produces("application/json")
	public List<Sample> getAllProducts(@QueryParam("filter") @DefaultValue("") String filter) {
		if (filter.equals("")){
			return bean.getSample();
		}
		return null;
	}
	
	@GET
	@Path("/{categoryName}")
	@Produces("application/json")
	public List<Sample> getProductsInCategory(@PathParam("categoryName") @DefaultValue("") String filter) {
		if (filter.equals("")){
			return bean.getSample();
		}
		return null;
	}
	
	@POST
    @Path("/post")
    @Consumes("text/plain")
    public Response postStrMsg(String msg) {
        String output = "POST:Jersey say : " + msg;
        bean.setSample(msg);
        return Response.status(200).entity(output).build();
    }
}
