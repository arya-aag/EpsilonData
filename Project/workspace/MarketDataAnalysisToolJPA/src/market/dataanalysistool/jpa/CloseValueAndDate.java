package market.dataanalysistool.jpa;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Embeddable;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;


public class CloseValueAndDate implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private Double close_;

	private Date x_Date;
	 


	
	
}
