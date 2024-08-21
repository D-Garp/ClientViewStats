Please navigate to ..\ClientViewStats\SQL Script
Open file SQLQuery.sql then F5 on SSMS
The script should return SQL connection string (for none windows login you might need to replace <<password>> with your user password)
Then replace value of variable connetionString with aquired connection string(aquired from above sql query) on class ..\ClientViewStats\ClientDataLibrary\CommonCode.cs