# Corporate-staff-management
This module also reports the company's monthly performance.

In this database, we have six tables, each of which is described below:
-TblUser: A table in which we define the username and password of the user, here we have a manager in db
    We created it and, for ease of use, we assigned the username and password from inside db, if you wish
    You can add editing and deleting add-ons and add manager.
    
-Users: This table stores employee information.
-Departments: In this table we define all parts of an organization and we can do this
    We divide an organization into small sections and make it easier to manage them.
    
-PagIbig: In this table, we will cover the company's monthly losses.In this table, we specify the position of the people.
-PhilHealth: In this table, we define the monthly salary of users.
-Positions: In this table, we specify the position of the people.
-SSS: In this table, we store the insurance information


* To execute the project on your computer execute the sql script
  Create the database, then in VisualStudio all the connections
  Change the following.
  
  SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=amps;Integrated Security=True")
