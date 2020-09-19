# Restaurant Management App (.NETCore3.1 MVC)


<hr />
<h3> Home Page with all controllers shown as dropdown lists in the menu bar</h3>
<img src="./Images/home.png">

<hr />
<h3> Authentication and Authorization require login to use different functions of the app </h3>
<img src="./Images/logIn.png">


<hr />
<h3> Person Controller allows inserting new employee, editing employee and viewing all employees in the database </h3>
<img src="./Images/insertPerson.png">
<img src="./Images/editPerson.png">
<img src="./Images/viewPersons.png">

<hr />
<h3> DiningTable Controller allows inserting new dining table, editing dining table and viewing all dining tables in the database </h3>
<img src="./Images/insertDiningTable.png">
<img src="./Images/editDiningTable.png">
<h3> The Edit link in table list allows redirecting to the Edit view and the Delete link allows deleting the corresponding table from the list </h3>  
<img src="./Images/viewDiningTables.png">

<hr />
<h3> Food Controller allows inserting new food type into the database, viewing all food types and deleting food type using the Delete link </h3>
<img src="./Images/insertFoodType.png">
<img src="./Images/viewFoodTypes.png">

<hr />
<h3> Food Controller also allows inserting new food, editing food, deleting food and viewing all foods in the database. Each food belongs to a specific food type. </h3>
<img src="./Images/insertFood.png">
<img src="./Images/editFood.png">
<img src="./Images/viewFoods.png">

<hr />
<h3> Order Controller allows creating new order based on table number. The table number and server name can be selected from the dropdown lists. The food type list and food name list are cascading dropdown lists. When a certain food type is chosen foods belong to the corresponding food type will be populated in the food name dropdown. When a certain food name is selected the price field will be automatically filled. After completing order for a table we can view the order summary by typing in the table number and submit the request. </h3>
<img src="./Images/insertOrder.png">

<hr />
<h3> Inside the order summary, the Details, Edit and Delete links allow viewing the details of, editing and deleting corresponding ordered food respectively. If there is no question about the order summary we can type in the table number and submit the order </h3>
<img src="./Images/orderDetails.png">
<img src="./Images/orderDetail.png">
<img src="./Images/editOrderDetail.png">


<hr />
<h3> Order Controller also allows searching for order details based on table number </h3>
<img src="./Images/searchOrder.png">
<h3> An error message will show up if currently there is no active order for the searched table </h3>
<img src="./Images/noOrderError.png">

<hr />
<h3> Order Controller also enables viewing the summary for all active orders. We can edit each order, view the food details of each order and delete order using the corresponding links </h3>
<img src="./Images/viewActiveOrder.png">
<img src="./Images/editOrder.png">

<hr />
<h3> Bill Controller allows searching the bill and view the bill details of each table. If there is no question about the bill we can type in the table number and submit the request to pay bill </h3>
<img src="./Images/searchBill.png">
<img src="./Images/billDetails.png">

<hr />
<h3> After the bill for a certain table is paid the order summary for this table number is removed from the active order summary table. The order Id is then assigned to each ordered food detail inside this order summary </h3>
<img src="./Images/beforePay.png">
<img src="./Images/afterPay.png">


<hr />
<h3> Although the order summary and order details of paid orders could not be reached using the Order Controller and Bill Controller we still can access these raw data using the Repository Controller </h3> 
<img src="./Images/viewAllOrders.png">
<img src="./Images/viewAllOrderDetails.png">



