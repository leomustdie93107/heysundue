## Classes as Models
1. Article:  
   - ID : int
   - Number : string?
   - ReleaseDate : DateTime
   - Gender : string?
   - Count : decimal
   - Date : DateTime
   - Time : TimeSpan
   - Location : string? <br />
   <br />
2. Login:  
   - ID : int
   - Username : string?
   - Password : string? <br />
   <br />
3. Accessdoor:  
   - ID : int
   - StartDate : string?
   - SearchColumn : string?
   - Room : string?
   - Session : string? <br />
   <br />
4. Doorsystem: 
   - ID : int
   - Date : DateTime
   - Session : string?
   - SessionName : string?
   - Room : string?
   - TimeRange : string? <br />
   <br />
5. Joinlist: 
   - ID : int
   - SearchColumn : string?
   - StartDate : string?
   - EndDate : string?
   - SearchKeyword : string?
   - Participants : string?
   - RegNo : string?
   - FirstName : string?
   - LastName : string?
   - ChineseName : string?
   - Country : string?
   - RegistrationStatus : string? <br />
   <br />
6. Person: 
   - ID : int
   - Name : string?
   - Age : int
   - Gender : string? <br />
   <br />
7. Registration: 
   - ID : int
   - DisplayLocation : string?
   - DisplayStatus : string? 
   - ItemName : string?
   - TotalAmount : int?
   - TotalAmountUSD : int? <br />
   <br />
8. ErrorViewModel: 
   - RequestId : string?
   - ShowRequestId : bool

## Database

### Create [DbContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-8.0)

1. Create `Data` folder
2. Create `HeysundueContext.cs`
3. Class name `HeysundueContext` derived from the class `DbContext`
