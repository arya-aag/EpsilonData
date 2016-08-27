package demos.jdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class SimpleJdbcDemo {

    public static void main(String[] args) {
        
        // Load Derby driver.
		try {
			Class.forName("com.mysql.jdbc.Driver");
		} catch (ClassNotFoundException e) {
		    System.out.println("Error loading driver: " + e);
		    return;
		}


        // Use database name if provided, else use the demo Derby database.
        String dbName;
        if (args.length == 1) {
            dbName = args[0];
        } else {
            dbName = "jdbc:mysql://localhost/mydatabase?user=root";
        }

        // Connect to a database.
        @SuppressWarnings("unused")
        Connection cnEmps = null;

        try {
            cnEmps = DriverManager.getConnection(dbName);
            System.out.println("Hooray!");
        } catch (SQLException e) {
            System.out.println("Error connecting to a database: " + e);
        }

    }
}
