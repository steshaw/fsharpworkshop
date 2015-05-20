namespace Services

open Data

type CustomerService() = 
    member this.GetCustomers () = getCustomers ()
    member this.UpgradeCustomer id =
        Data.getCustomers ()
        |> Seq.find (fun c -> c.Id = id)
        |> Functions.upgradeCustomer