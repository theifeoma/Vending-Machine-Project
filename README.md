# Vending-Machine-Project

This project involves building a vending machine system that allows users to purchase snacks using coins in specific denominations. 
The system maintains a pool of change totalling £12 and cannot create additional change. 
The quantity of snacks is reduced by 1 upon purchase, and only one snack can be sold per transaction. 
The system will display "* out of stock *" if the snack is not available for purchase. 
A suitable design pattern (chain of resposibilities) is employed for dispensing change due to the customer, and the transaction will be rejected if the snack is out of stock or if the machine cannot provide change. 
A secret admin menu is available for administrators to change snack prices, increase the change pool, and see the total amount of money in the machine.
