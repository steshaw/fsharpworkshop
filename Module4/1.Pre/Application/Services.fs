namespace Services

open Data
open Functions

type CustomerService() = 
    member this.GetCustomers () = loadCustomers ()
    member this.UpgradeCustomer id =
        loadCustomers ()
        |> Seq.find (fun c -> c.Id = id)
        |> upgradeCustomer