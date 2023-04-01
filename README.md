# Vending-Machine-Project

Allow a user to purchase a snack.

Upon purchasing a snack, the system will invite the user to enter coinsonly in the following denominations until the amount due is met orexceeded:• £2• £1• £0.50• £0.20• £0.10• £0.05. 

Upon completing the purchase, the quantity of the snack will be reduced by 1. 

The machine should sell only one snack per transaction.

If a snack has a quantity of zero, it shall display * out of stock * and the snack cannotbe purchased.

The Machine must start with a pool of change totalling £12 in the previously described denominations

Change must be dispensed from this pool.
  • Any new coins inserted when paying for a snack shall be added to the change pool. Note that the machine cannot create change and can only give change from this pool.
  • The solution shall employ the use a known design pattern suitable fordispensing any change due to the customer. You are required to identify asuitable design pattern and employ it as part of your solution.
  
The Machine shall reject the transaction if the snack is out of stock or the machine isunable to provide change.

A secret admin menu shall be available and accessible from the main menu throughentering a special pin: 1011 and password “A5144I”. The admin menu shall allow for an administrator to:
  • Change the snack prices.
  • Increase the change pool.
  • See the total amount of money presently in the machine


