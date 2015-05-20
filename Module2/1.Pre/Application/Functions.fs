module Functions

open Types

let tryPromoteToVip (customer, spendings) =
    if spendings > 100.0 then { customer with IsVip = true }
    else customer

let getSpendings customer =
    if customer.Id % 2 = 0 then (customer, 120.0)
    else (customer, 80.0)

let increaseCredit predicate customer =
    if predicate customer then { customer with Credit = customer.Credit + 100.0 }
    else { customer with Credit = customer.Credit + 50.0 }

let isVip customer = customer.IsVip

let increaseCreditUsingVip = increaseCredit isVip

let upgradeCustomer customer =
    customer
        |> getSpendings
        |> tryPromoteToVip
        |> increaseCreditUsingVip