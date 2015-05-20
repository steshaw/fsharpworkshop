﻿module Tests

open System
open Xunit
open Swensen.Unquote
open Types
open Functions
open Services

let customer = 
        { Id = 1 
          IsVip = false 
          Credit = 0.0<USD>
          PersonalDetails = Some { FirstName = "John"; 
                                   LastName = "Doe"; 
                                   DateOfBirth = DateTime(1970, 11, 23) }
          Notifications = ReceiveNotifications(receiveDeals = true, 
                                               receiveAlerts = true) }

[<Fact>]
let ``4-1 Get spendings by month for customer 1``() =
    let spendings = getSpendingsByMonth customer
    test <@ spendings = List.init 12 (fun x -> 60.0) @>

[<Fact>]
let ``4-2 Weighted mean``() =
    let items = [(60.0, 1.0); (70.0, 0.5)]
    let result = weightedMean items
    test <@ result = 47.5 @>

[<Fact>]
let ``4-3 Get spendings using weighted mean``() =
    let spendings = getSpendings customer
    test <@ spendings = (customer, 53.0) @>

[<Fact>]
let ``4-4 Get customers``() =
    let service = CustomerService()
    let customers = service.GetCustomers ()
    test <@ Seq.length customers = 4 @>

[<Fact>]
let ``4-5 Update customer``() =
    let service = CustomerService()
    let upgradedCustomer = service.UpgradeCustomer 2
    test <@ upgradedCustomer.IsVip @>
    test <@ upgradedCustomer.Credit = 110.0<USD> @>