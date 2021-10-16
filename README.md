# Bankomaten
This program works as a ATM machine for 5 users. If the user succeeds to log in, it's pre set accounts with pre set values are shown. 
If the user writes the wrong password 3 times, the program is terminated.
When the user is logged in, it can chose to transfer money between it's own accounts, make a cash withdrawal or sign out.

When building the program, I first made the same amount of accounts for each user, and structured the program here after. When I found out
that the users should have different amount of accounts, I had to make a big recontstuction of the program. To make the program work without totally
starting over, I had to hard code a lot of the values in the program. It's therefore not possible to add users or account in the way it's now structured.
Also a lot of code with only a small change, is repeated several times which makes it a lot of code.

If I would do it over again, I would have chosen to put the users in a separate class, to make changes more easily, and also more easily transfer user values of
different variables within the program. I would also have avoided to put all the users, with their accounts and values in the same 2-dimensional array, since this 
made the searching for values within the array more difficult as the users had different amount of accounts. This would have saved the program from a lot
of code.
