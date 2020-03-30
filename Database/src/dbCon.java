import java.sql.*;

public class dbCon {

    public static void main(String args[]) {
        // getting connected to database, called it blooddb
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection con = DriverManager.getConnection
                    ("jdbc:mysql://localhost:3306/blooddb","root","password");
            //function to make all the database tables
            makeDB(con);

        }
        catch(Exception e) {System.out.println(e);}
    }

    private static void makeDB(Connection con) throws SQLException {
        //started on making the database
        Statement stmt = con.createStatement();
        String clinic = "CREATE TABLE CLINIC " +
                " (clinicID INTEGER not NULL, " +
                " PhoneNo INTEGER not NULL, " +
                " ClinicLocation VARCHAR(255), " +
                " EmployeeID INTEGER not NULL, " +
                "PRIMARY KEY ( clinicID ))";
        stmt.executeUpdate(clinic);



    }

}
